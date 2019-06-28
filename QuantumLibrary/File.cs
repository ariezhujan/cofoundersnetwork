using System;
using System.IO;
using System.Net;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;
using Brettle.Web.NeatUpload;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.Drawing;

namespace QuantumLibrary
{
    public class CookieAwareWebClient : WebClient
    {
        private CookieContainer m_container = new CookieContainer();
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }
            return request;
        }
    }

    /// <summary>
    /// Summary description for File
    /// </summary>
    public class File
    {
        public const int fileType_all = 0;
        public const int fileType_misc = 1;
        public const int fileType_game = 2;
        public const int fileType_animation = 3;
        public const int fileType_soundboard = 4;
        public const int fileType_embedVideo = 5;
        public const int fileType_musicAlbum = 6;
        public const int fileType_competition = 7;
        public const int fileType_video = 8;
        public const int fileType_gallery = 9;
        public const int fileType_image = 10;
        public const int fileType_adultContentPortal = 11;

        public const int fileReplyToCategory_File = 0;
        public const int fileReplyToCategory_News = 1;
        public const int fileReplyToCategory_CrewPage = 2;
        public const int fileReplyToCategory_Battle = 3;
        public const int fileReplyToCategory_Happenings = 4;
        public const int fileReplyToCategory_Gallery = 5;

        public static readonly string saveLocationFiles_Perm = Data.ReadSetting("rootDirectoryPhysicalPath") + Data.ReadSetting("logicalPathFiles");
        public static readonly string saveLocationFiles_Temp = Data.ReadSetting("rootDirectoryPhysicalPath") + Data.ReadSetting("logicalPathFilesTemp");
        public static readonly string uploadedFilesDirectory = "files";

        #region Fields
        //temp
        public static readonly float defaultMaxTotalAmount = 10000000000; //10,000 meg

        //public static readonly float defaultMaxTotalAmount = 500000000; //500 meg
        //public static readonly float defaultMaxUploadAmount_Regular = 10000000; //10 meg
        public static readonly float defaultMaxUploadAmount_Regular = 10000000000; //10,000 meg
        //public static readonly float defaultMaxUploadAmount_Pro = 30000000; //30 meg
        public static readonly float defaultMaxUploadAmount_Pro = 10000000000; //10,000 meg

        public static readonly string privacy_public = "p";
        public static readonly string privacy_private = "r";
        public static readonly string privacy_private_hotlinkingDisabled = "h";

       
        public string fileName = "", description = "", location = "", location_thumb_video_9070 = "", privacy = "", s_image = "", tags = "", ext = "", externalID = "";
        public float fileSize = 0;
        public DateTime createdDate, deletedDate;
        public int userID = 0, projectID = 0, goalID = 0, custom_width = 0, custom_height = 0, num_views = 0, fileType = 0, replyToFileID = 0, replyToCategoryID = 0, popularity = 0, count_like = 0, count_dislike = 0, count_report = 0;
        public bool allow_comments = true, admin_approved = false, admin_featured = false;

        private string _title = "";
        public string title
        {
            set
            {
                _title = value.Trim();
            }
            get
            {
                return _title;
            }
        }

        public bool location_thumb_video_9070_exists
        {
            get
            {
                if (this.location_thumb_video_9070 == "")
                {
                    return false;
                }
                return true;
            }
        }

        private int ID;

        public string image
        {
            get
            {
                return s_image.Replace("\\", "/");
            }
            set
            {
                s_image = value;
            }
        }

        public string image_videoFrame
        {
            get
            {
                return this.image.Insert(this.image.LastIndexOf("/") + 1, "video_");
            }
        }

        public int id
        {
            get
            {
                return ID;
            }
        }

        public static string LocationPhysical_TempFolder(string fileName)
        {
            return File.SaveFolder() + "Temp\\" + fileName;
        }

        public static string LocationPhysical(string locationRelative)
        {
            return File.SaveFolder() + locationRelative.Replace("/", "\\");
        }

        public string locationPhysical
        {
            get
            {

                return File.LocationPhysical(this.location);
            }
        }

        public string name
        {
            get
            {
                if (title.Trim() != "")
                {
                    return title;
                }
                else if (fileName.Trim() != "")
                {
                    return fileName;
                }
                else
                {
                    return "File " + id.ToString();
                }
            }
        }



        /// <summary>
        /// Return the file type name according to the file type
        /// </summary>
        public string fileTypeName
        {
            get
            {
                switch (fileType)
                {
                    case 1:
                        return "File";
                        break;
                    case 2:
                        return "Flash Game";
                        break;
                    case 3:
                        return "Flash Animation";
                        break;
                    case 4:
                        return "Flash Soundboard";
                        break;
                    default:
                        return "File";
                        break;
                }
            }
        }

        #endregion



        #region Modify

        /// <summary>
        /// Constructior
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        public File()
        {
            ID = 0;
            userID = 0;

            description = "";
        }

        public File(int id)
        {
            ID = id;
            Load(id);
        }

        /// <summary>
        /// Create new file
        /// </summary>
        /// <returns></returns>
        public bool Create()
        {
            //int id = int.Newint();
            DBAccess conn = new DBAccess("file_Create");
            conn.AddParameter("@fileName", fileName);
            conn.AddParameter("@ext", ext.ToLower().Trim());
            conn.AddParameter("@fileSize", fileSize);
            conn.AddParameter("@userID", userID);

            object objUserID = conn.ExecuteScalar();
            ID = int.Parse(objUserID.ToString());

            return true;
        }

        /// <summary>
        /// Delete file
        /// </summary>
        /// <returns></returns>
        public bool Delete(HttpServerUtility server)
        {
            //try and delete the file
            try
            {
                //physically
                System.IO.File.Delete(SaveFolder(server) + this.location);
                System.IO.File.Delete(SaveFolder(server) + this.image);
            }
            catch (Exception ex)
            {
                //return false;
            }

            //from the database
            DBAccess conn = new DBAccess("file_Delete");
            conn.AddParameter("@ID", this.id);
            conn.ExecuteNonQuery();

            return true;

        }

        public static bool Delete(HttpServerUtility server, string location, string image, int fileID)
        {
            //try and delete the file
            try
            {
                //physically
                System.IO.File.Delete(SaveFolder(server) + location);
                System.IO.File.Delete(SaveFolder(server) + image);
            }
            catch (Exception ex)
            {
                //return false;
            }

            //from the database
            DBAccess conn = new DBAccess("file_Delete");
            conn.AddParameter("@ID", fileID);
            conn.ExecuteNonQuery();

            return true;

        }



        /// <summary>
        /// Update file
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            //save tags
            SaveTags();

            DBAccess conn = new DBAccess("file_Update");
            conn.AddParameter("@ID", id);
            conn.AddParameter("@userID", userID);
            conn.AddParameter("@projectID", projectID);
            conn.AddParameter("@description", description);
            conn.AddParameter("@tags", tags);
            conn.AddParameter("@title", title);
            conn.AddParameter("@location", location);
            conn.AddParameter("@privacy", privacy.Trim());
            conn.AddParameter("@allow_comments", allow_comments);
            conn.AddParameter("@custom_width", custom_width);
            conn.AddParameter("@custom_height", custom_height);
            conn.AddParameter("@num_views", num_views);
            conn.AddParameter("@fileType", fileType);
            conn.AddParameter("@image", image);
            conn.AddParameter("@externalID", externalID);
            conn.AddParameter("@replyToFileID", replyToFileID);
            conn.AddParameter("@replyToCategoryID", replyToCategoryID);            
            conn.AddParameter("@count_report", count_report);
            conn.AddParameter("@admin_approved", admin_approved);
            conn.AddParameter("@admin_featured", admin_featured);
            conn.AddParameter("@location_thumb_video_9070", location_thumb_video_9070);
            

            conn.ExecuteNonQuery();

            ID = id;

            return true;
        }

        public static void SaveLike(int fileid, int userid, bool like)
        {
            DBAccess conn = new DBAccess("file_SetLike");
            conn.AddParameter("@fileID", fileid);
            conn.AddParameter("@userid", userid);
            conn.AddParameter("@like", like);
            conn.ExecuteNonQuery();
        }

        private void SaveFileTag(string tag)
        {
            DBAccess conn = new DBAccess("file_SaveTag");
            conn.AddParameter("@fileID", id);
            conn.AddParameter("@tag", tag);
            conn.ExecuteNonQuery();
        }

        public static int SaveTag(string name)
        {
            DBAccess conn = new DBAccess("tag_Save");
            conn.AddParameter("@name", name);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["ID"];
            else
                return 0;
        }

        public static void SaveTagLink(int tagID, int tagID_Link)
        {
            DBAccess conn = new DBAccess("tag_SaveLink");
            conn.AddParameter("@tagID", tagID);
            //conn.AddParameter("@tag_Link", tag_Link);
            //if available, pass through the tag_Link tagID so the query doesnt need to search
            if (tagID_Link != 0) {
                conn.AddParameter("@tagID_Link", tagID_Link);
            } 
            conn.ExecuteNonQuery();
        }

        //removes all redirects to this tag
        public static void RemoveTagRedirects(int tagID)
        {
            DBAccess conn = new DBAccess("tag_RemoveRedirects");
            conn.AddParameter("@tagID", tagID);
            conn.ExecuteNonQuery();
        }

        //creates a redirect from tag_Redirect to tagID
        public static void SaveTagRedirect(int tagID, string tag_Redirect)
        {
            DBAccess conn = new DBAccess("tag_SaveRedirect");
            conn.AddParameter("@tagID", tagID);
            conn.AddParameter("@tag_Redirect", tag_Redirect);
            conn.ExecuteNonQuery();
        }

        public static void SaveImage(string imageURL_Original, string imageURL_Thumb, int tagID, int importance)
        {
            DBAccess conn = new DBAccess("tag_SaveImage");
            conn.AddParameter("@imageURL_Original", imageURL_Original);
            conn.AddParameter("@imageURL_Thumb", imageURL_Thumb);
            conn.AddParameter("@tagID", tagID);
            conn.AddParameter("@importance", importance);
            conn.ExecuteNonQuery();
            //if (ds.Tables[0].Rows.Count > 0)
            //    return (int)ds.Tables[0].Rows[0]["ID"];
            //else
            //    return 0;
            return;
        }

        public static void UpdateImage(string imageURL_Original, string imageURL_Thumb, int imageID)
        {
            DBAccess conn = new DBAccess("image_Update");
            conn.AddParameter("@imageID", imageID);
            conn.AddParameter("@imageURL_Original", imageURL_Original);
            conn.AddParameter("@imageURL_Thumb", imageURL_Thumb);
            conn.ExecuteNonQuery();
        }

        public static void DeleteImage(int imageID)
        {
            DBAccess conn = new DBAccess("image_Delete");
            conn.AddParameter("@imageID", imageID);
            conn.ExecuteNonQuery();
        }

        public static DataSet GetImages(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetImages");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        /// <summary>
        /// Save the videos to the database.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="maxRecordsToSave"></param>
        public static void SaveVideos(YoutubeSearch.YoutubeSearchResult result, int maxRecordsToSave, int tagID, int topicID, int videoSearchId)
        {
            int count = 1;
            foreach (var video in result.Videos)
            {
                File.SaveVideo(video.Id.VideoId, video.Snippet.Thumbnails.Medium.Url, video.Snippet.Title, video.Snippet.Description, 0, 0, 0, video.Snippet.ChannelTitle, video.Snippet.PublishedAt.Value, tagID, count, topicID, videoSearchId);
                count++;
                if (count > (maxRecordsToSave+1)) { break; }
            }
        }
        public static int SaveVideo(string videoURL_Original, string videoURL_Thumb, string title, string description, int duration_h, int duration_m, int views, string channel, DateTime date_Posted, int tagID, int importance, int topicID, int videoSearchId)
        {
            DBAccess conn = new DBAccess("tag_SaveVideo");
            conn.AddParameter("@title", title);
            conn.AddParameter("@Description", description);
            conn.AddParameter("@Duration_h", duration_h);
            conn.AddParameter("@Duration_m", duration_h);
            conn.AddParameter("@Views", views);
            conn.AddParameter("@Channel", channel);
            conn.AddParameter("@Date_Posted", date_Posted);
            conn.AddParameter("@videoURL_Original", videoURL_Original);
            conn.AddParameter("@videoURL_Thumb", videoURL_Thumb);
            conn.AddParameter("@tagID", tagID);
            conn.AddParameter("@importance", importance);
            if(topicID!=0)
                conn.AddParameter("@topicID", topicID);
            if (videoSearchId != 0)
                conn.AddParameter("@videoSearchId", videoSearchId);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["ID"];
            else
                return 0;
        }

        public static void DeleteVideos(int tagID, int topicID)
        {
            DBAccess conn = new DBAccess("tag_DeleteVideos");
            conn.AddParameter("@tagID", tagID);
            conn.AddParameter("@topicID", topicID);
            conn.ExecuteNonQuery();       
        }

        //save the wikidataQCode (claim_value_wikidataQCode) to the database against the wikipediaName 
        //if the wikipediaName does not exist in the database, create the tag record 
        //return the tagID
        public static int SaveTagWikidataQCode(string tag, string wikidataQCode)
        {
            DBAccess conn = new DBAccess("tag_SaveWikidataQCode");
            conn.AddParameter("@tag", tag);
            conn.AddParameter("@wikidataQCode", wikidataQCode);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["ID"];
            else
                return 0;
        }

        /// <summary>
        /// Wikipedia
        /// </summary>
        /// <param name="tagID"></param>
        public static void DeleteTagLinks(int tagID)
        {
            DBAccess conn = new DBAccess("tag_DeleteTagLinks");
            conn.AddParameter("@tagID", tagID);
            conn.ExecuteNonQuery();
        }
        
        /// <summary>
        /// Wikidata
        /// </summary>
        /// <param name="tagID"></param>
        public static void DeleteTagStatements(int tagID)
        {
            DBAccess conn = new DBAccess("tag_DeleteTagStatements");
            conn.AddParameter("@tagID", tagID);
            conn.ExecuteNonQuery();
        }

        public static DataSet GetTopicsForTag(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTopics");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        /// <summary>
        /// Returns summary information such as description and number of statements in the database
        /// </summary>
        /// <param name="tagID"></param>
        /// <returns></returns>
        public static DataSet GetTagDetailsSummary(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetDetails_Summary");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }        

        /// <summary>
        /// Gets the lowest relevance value for images for a  tag. If returns 1 then high quality images exists. 0 means no images. 100 means wikipedia images.
        /// </summary>
        /// <param name="tagID"></param>
        public static int GetTagImageLowestRelevance(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagImageLowestImportanceValue");
            conn.AddParameter("@tagID", tagID);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["importance"];
            else
                return 0;
        }

        public static int GetTagVideoLowestRelevance(int tagID, int topicID)
        {
            DBAccess conn = new DBAccess("tag_GetTagVideoLowestImportanceValue");
            conn.AddParameter("@tagID", tagID);
            if(topicID!=0)
                conn.AddParameter("@topicID", topicID);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["importance"];
            else
                return 0;
        }

        /// <summary>
        /// Returns the number of videos 
        /// </summary>
        /// <param name="tagID"></param>
        /// <param name="topicID"></param>
        /// <returns></returns>
        public static int GetTagVideoCount(int tagID, int topicID)
        {
            DBAccess conn = new DBAccess("tag_GetTagVideoCount");
            conn.AddParameter("@tagID", tagID);
            if (topicID != 0)
                conn.AddParameter("@topicID", topicID);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["videoCount"];
            else
                return 0;
        }

        public static void SaveTagDetails(int tagID, DateTime dateParsed, string wikidataID, string tagDescription)
        {
            DBAccess conn = new DBAccess("tag_SaveDetails");
            conn.AddParameter("@tagID", tagID);
            conn.AddParameter("@DateParsed", dateParsed);
            conn.AddParameter("@WikidataQCode", wikidataID);
            conn.AddParameter("@Description", tagDescription);
            conn.ExecuteNonQuery();
        }

        public static int SaveTagStatement(int tagID, int statementID, int propertyID, int claim_propertyID, int claim_value_tagID, int claim_value_int, DateTime claim_value_date, decimal claim_value_decimal, string claim_value_string)
        {
            DBAccess conn = new DBAccess("statement_Save");
            if (tagID != 0)
                conn.AddParameter("@Item_tagID", tagID); //the tag the statement is for. 
            if (statementID != 0)
                conn.AddParameter("@Item_statementID", statementID); //statements can have additional statements. e.g. The statement 'pronunciation audio' for jupiter has statements that then have properties 'language of work or name'.
            //conn.AddParameter("@Item_propertyID", propertyID); //properties can have statements about them. e.g. the property 'instance of' has a property 'see also'.
            conn.AddParameter("@PropertyID", claim_propertyID); //the property type of the statement. e.g. 'instance of'
            if (claim_value_tagID != 0)
                conn.AddParameter("@Value_tagID", claim_value_tagID); //the id of the tag if the wikidata statement points to another wikidata item
            if (claim_value_int != 0) 
                conn.AddParameter("@Value_int", claim_value_int);
            if (claim_value_date!=Data.defaultDateTime()) 
                conn.AddParameter("@Value_date", claim_value_date, SqlDbType.DateTime2, 7, ParameterDirection.Input);
            if (claim_value_decimal != 0) 
                conn.AddParameter("@Value_decimal", claim_value_decimal);
            if (claim_value_string != "") 
                conn.AddParameter("@Value_string", claim_value_string);

            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return Data.validInt(ds.Tables[0].Rows[0]["StatementID"].ToString());
            else
                return 0;
        }

        public static DataSet GetTagsToBeParsed()
        {
            DBAccess conn = new DBAccess("tag_GetToBeParsed");
            return conn.ExecuteReader();
        }

        public static DataSet GetTagsWithLinkWeights()
        {
            DBAccess conn = new DBAccess("tag_GetTagsWithLinkWeights");
            return conn.ExecuteReader();
        }

        public static string GetTagByID(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetByID");
            conn.AddParameter("@tagID", tagID);
            DataSet ds = conn.ExecuteReader();
            return ds.Tables[0].Rows[0]["name"].ToString();
        }

        public static int GetTagIDByName(string tag)
        {
            DBAccess conn = new DBAccess("tag_GetByName");
            conn.AddParameter("@tag", tag);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["ID"];
            else
                return 0;
        }

        public static DataSet GetProperties()
        {
            DBAccess conn = new DBAccess("property_GetAll");
            return conn.ExecuteReader();
        }

        public static DataSet GetTags()
        {
            DBAccess conn = new DBAccess("tag_GetAll");
            return conn.ExecuteReader();
        }

        public static int SaveProperty(string wikidataPCode, string name)
        {
            DBAccess conn = new DBAccess("property_Save");
            conn.AddParameter("@wikidataPCode", wikidataPCode);
            conn.AddParameter("@name", name);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["ID"];
            else
                return 0;
        }

        /// <summary>
        /// Returns the tagID with the wikidataQCode assigned within the tag details table.
        /// </summary>
        /// <param name="wikidataQCode"></param>
        /// <returns></returns>
        public static int GetTagIDByWikidataQCode(string wikidataQCode)
        {
            DBAccess conn = new DBAccess("tag_GetByWikidataQCode");
            conn.AddParameter("@wikidataQCode", wikidataQCode);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["TagID"];
            else
                return 0;
        }

        public static DataSet GetTagLinks(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinks");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //Returns tags that link from the tag (wikidata)
        public static DataSet GetTagLinkedFrom_Wikidata(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedFrom_Wikidata");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //Returns tags that link to the tag (wikidata)
        public static DataSet GetTagLinkedTo_Wikidata(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedTo_Wikidata");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //Returns tags that link to this tag
        public static DataSet GetTagLinkedTo_Detailed(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedTo_Detailed");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //Returns tags that are linked from this tag (linked off this wiki page)
        public static DataSet GetTagLinkedFrom_Detailed(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedFrom_Detailed");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //tags linking to and from quantum
        public static DataSet GetTagLinkedToAndFrom_Detailed(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedToAndFrom_Detailed");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        //commonalities of tags linking to and from quantum
        public static DataSet GetTagLinkedToAndFrom_Commonalities_Detailed(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinkedToAndFrom_Commonalities_Detailed");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        public static DataSet GetTagLinksWeighted(int tagID)
        {
            DBAccess conn = new DBAccess("tag_GetTagLinksWeighted");
            conn.AddParameter("@tagID", tagID);
            return conn.ExecuteReader();
        }

        private void DeleteTags()
        {
            DBAccess conn = new DBAccess("file_DeleteTags");
            conn.AddParameter("@fileID", id);
            conn.ExecuteNonQuery();
        }


        public void SaveTags()
        {
            //delete exiting tags
            DeleteTags();

            //remove all characters not letters or numbers
            tags = Regex.Replace(tags, "[^a-zA-Z0-9 ]", " ").ToLower().Trim();

            //remove duplicate words
            tags = Data.RemoveDuplicateWords(tags);

            //break tags variable into words
            tags = tags.Replace(Environment.NewLine, " ").Replace("\n", "").Replace("\r", "").Replace("  ", " ").Replace("  ", " ");
            string[] tagsSplit = tags.Split(' ');

            //for each word(tag)
            int count = tagsSplit.Length;
            int x = 0;
            while (x < count)
            {
                //for each tag in the variable tags, save
                if (tagsSplit[x] != "" && tagsSplit[x] != "swf")
                {
                    SaveFileTag(tagsSplit[x]);
                }

                x++;
            }
        }

        //adds +1 for the num_views column
        public void AddView()
        {
            try
            {
                DBAccess conn = new DBAccess("file_AddView");
                conn.AddParameter("@ID", this.id);
                conn.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //ignore error for user, record for system
                QuantumLibrary.SystemError.Record(ex);
            }
        }

        public static File Load_FromCache(int objectId, System.Web.UI.Page page)
        {
            File file;

            //check if it exists in the cache
            if (true || page.Cache["fileObject" + objectId.ToString()] == null)
            {
                //if it doesnt, get and store in cache    
                //TimeSpan span = new TimeSpan(0,10,0);
                file = new File();
                file.Load(objectId);
                page.Cache.Insert("fileObject" + objectId.ToString(), file, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                return file;
            }

            //return from cache
            return (File)page.Cache["fileObject" + objectId.ToString()];
        }

        public static DataSet Load_FromCache_Suggestions(int objectId, System.Web.UI.Page page)
        {
            return File.GetSuggested(objectId);

            //DataSet ds;

            ////check if it exists in the cache
            //if (page.Cache["fileSuggestions" + objectId.ToString()] == null)
            //{
            //    //if it doesnt, get suggestions and store in cache    
            //    ds = File.GetSuggested(objectId);
            //    page.Cache.Insert("fileSuggestions" + objectId.ToString(), ds, null, DateTime.Now.AddMinutes(60), System.Web.Caching.Cache.NoSlidingExpiration);
            //    return ds;
            //}

            ////return from cache
            //return (DataSet)page.Cache["fileSuggestions" + objectId.ToString()];
        }

        public static void Delete_FromCache_Suggestions(int objectId, System.Web.UI.Page page)
        {
            //check if it exists in the cache
            if (page.Cache["fileSuggestions" + objectId.ToString()] != null)
            {
                page.Cache.Remove("fileSuggestions" + objectId.ToString());
            }
        }


        public static void Delete_FromCache(int objectId, System.Web.UI.Page page)
        {
            //check if it exists in the cache
            if (page.Cache["fileObject" + objectId.ToString()] != null)
            {
                page.Cache.Remove("fileObject" + objectId.ToString());
            }
        }

        /// <summary>
        /// Load file
        /// </summary>
        /// <returns></returns>
        public bool Load(int objectId)
        {
            DBAccess conn = new DBAccess("file_Get");
            conn.AddParameter("@ID", objectId);

            //load details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                fileName = dr["fileName"].ToString();
                ext = dr["ext"].ToString();
                title = dr["title"].ToString();
                description = dr["description"].ToString();
                tags = dr["tags"].ToString();
                location = dr["location"].ToString();
                location_thumb_video_9070 = dr["location_thumb_video_9070"].ToString();
                description = dr["description"].ToString();
                privacy = dr["privacy"].ToString().Trim();
                image = dr["image"].ToString();
                externalID = dr["externalID"].ToString();

                custom_width = Data.validInt(dr["custom_width"].ToString());
                custom_height = Data.validInt(dr["custom_height"].ToString());
                num_views = Data.validInt(dr["num_views"].ToString());
                fileType = Data.validInt(dr["fileType"].ToString());

                projectID = Data.validInt(dr["projectID"].ToString());

                allow_comments = Data.validBool(dr["allow_comments"].ToString());

                createdDate = Data.validDateTime(dr["createdDate"].ToString());
                deletedDate = Data.validDateTime(dr["deletedDate"].ToString());
                userID = Data.validInt(dr["userID"].ToString());

                replyToFileID = Data.validInt(dr["replyToFileID"].ToString());
                replyToCategoryID = Data.validInt(dr["replyToCategoryID"].ToString());

                popularity = Data.validInt(dr["popularity"].ToString());
                count_like = Data.validInt(dr["count_like"].ToString());
                count_dislike = Data.validInt(dr["count_dislike"].ToString());


                count_report = Data.validInt(dr["count_report"].ToString());
                admin_approved = Data.validBool(dr["admin_approved"].ToString());
                admin_featured = Data.validBool(dr["admin_featured"].ToString());
            }

            ID = objectId;
            return true;
        }


        public static int GetIDWhereLocationLike(string value)
        {
            DBAccess conn = new DBAccess("file_GetIDWhereLocationLike");
            conn.AddParameter("@value", value);

            //load details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                return Data.validInt(dr["id"].ToString());
            }

            return 0;
        }


        public void CreateIconImage()
        {
            //if file is image and icon image has not been loaded, create icon from file
            if (this.image.Trim() == "")
            {
                if (File.FileExtension_Image(this.ext))
                {
                    CreateIconImage_FromImage();
                }
                else if (this.ext == "embed")
                {
                    CreateIconImage_FromEmbedLink();

                    //get details from external link
                    GetDetails_FromEmbedLink();
                }
                else if (this.ext == "swf")
                {
                    //open in thread because the function can take a while
                    Thread thread = new Thread(CreateIconImage_FromSWF);
                    thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA - browserthumbnail class doesnt work otherwise
                    thread.Start();
                }
                else if (this.ext == "fla")
                {
                    //if fla, and fla is in response to a swf file, use image icon of swf file
                    if (this.replyToFileID != 0)
                    {
                        //get reply file
                        File replyFile = new File();
                        replyFile.Load(this.replyToFileID);
                        if (replyFile.ext == "swf" && replyFile.image != "")
                        {
                            //copy image and use for this file
                            string replyImageLocation_Relative = replyFile.image;
                            string flaImageLocation_Relative = replyImageLocation_Relative.Insert(replyImageLocation_Relative.LastIndexOf("."), "flaReply" + this.id.ToString());

                            //copy to new location (using physical paths)
                            System.IO.File.Copy(File.LocationPhysical(replyImageLocation_Relative), File.LocationPhysical(flaImageLocation_Relative));

                            //save
                            this.image = flaImageLocation_Relative;
                            this.Update();
                        }
                    }
                }
            }
            else
            {
                string originalUploadedImage = this.image;

                //create icon from uploaded image
                //this.image = Image.CreateIconImage(this.image, false);
                this.Update();

                //delete uploaded image
                System.IO.File.Delete(File.LocationPhysical(originalUploadedImage));
            }
        }

        /// <summary>
        /// Function creates a icon image for an image file and returns the saved location of the icon file
        /// </summary>
        /// <param name="filePhysicalLocation"></param>
        /// <returns></returns>
        private void CreateIconImage_FromImage()
        {
            CreateIconImage(250, 0);
            this.Update();
        }

        public void CreateIconImage(int resizeHeight, int resizeWidth)
        {
            //only create icon images for jpg and png images
            if (this.ext != Image.extension_JPEG && this.ext != Image.extension_JPG && this.ext != Image.extension_PNG && this.ext != Image.extension_GIF)
            { return; }

            System.Drawing.Image image = System.Drawing.Image.FromFile(this.locationPhysical);
            int srcWidth = image.Width;
            int srcHeight = image.Height;

            Decimal sizeRatio = ((Decimal)srcHeight / srcWidth);
            int thumbHeight = 0, thumbWidth = 0;
            if (resizeHeight != 0 && resizeWidth != 0)
            {
                throw new Exception("Cannot create thumb and maintain ratio with both height and width specified.");
            }
            else if (resizeHeight != 0)
            {
                thumbHeight = resizeHeight;
                thumbWidth = Decimal.ToInt32(thumbHeight / sizeRatio);
            }
            else if (resizeWidth != 0)
            {
                thumbWidth = resizeWidth;
                thumbHeight = Decimal.ToInt32(thumbWidth * sizeRatio);
            }

            Bitmap bmp = new Bitmap(thumbWidth, thumbHeight);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(bmp);

            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            System.Drawing.Rectangle rectDestination = new System.Drawing.Rectangle(0, 0, thumbWidth, thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);

            this.image = this.location.Replace(".", "thumb.");
            bmp.Save(LocationPhysical(this.image), System.Drawing.Imaging.ImageFormat.Jpeg);

            bmp.Dispose();
            image.Dispose();
        }

        private void CreateIconImage_FromEmbedLink()
        {
            try
            {
                //save location of the icon file
                string iconLocationRelative = "embedIcons\\" + this.location.Replace("'", "").Replace("\"", "").Replace("\\", "").Replace("/", "").Replace(":", "").Replace("?", "").Replace("=", "").Replace("&", "").Replace(".", "") + ".jpg";
                string iconLocationPhysical = LocationPhysical(iconLocationRelative);

                //if liveleak or youtube
                string externalID, returnMessage = "";
                if (this.location.Contains("liveleak.com"))
                {
                    string iconURL = CreateIconImage_FromEmbedLink_LiveLeak(iconLocationRelative);
                    SaveFile(iconURL, iconLocationPhysical, ref returnMessage);
                }
                else if (this.location.Contains("youtube.com"))
                {
                    externalID = ReturnExternalLinkID(this.location, File.externalLink_youtube);

                    //download icon (http://img.youtube.com/vi/pwpW_sZRl8o/1.jpg)
                    string iconUrl = "http://img.youtube.com/vi/" + externalID + "/1.jpg";
                    SaveFile(iconUrl, iconLocationPhysical, ref returnMessage);
                }

                //update the object with the icon location
                //this.image = Image.CreateIconImage(iconLocationRelative, true);
                this.Update();

                //delete downloaded icon
                System.IO.File.Delete(iconLocationPhysical);
            }
            catch (Exception ex)
            {
                Event.SaveEvent("Icon unable to be created for embed file " + this.ID.ToString() + " - error: " + ex.Message.ToString(), Event.Type_System_AutoIconCreation_Failed);
            }
        }


        private string CreateIconImage_FromEmbedLink_LiveLeak(string iconLocationRelative)
        {
            string externalID = ReturnExternalLinkID(this.location, File.externalLink_liveLeakI);
            string tempPage = LocationPhysical(iconLocationRelative + ".html");
            string returnMessage = "";

            //download the page and get the icon code from the head
            //<meta property="og:image" content="http://edge.liveleak.com/80281E/u/u/thumbs/2011/Nov/20/d3133344680d_thumb_1.jpg"/>
            SaveFile(this.location, tempPage, ref returnMessage);

            //return the icon location (url)
            //open file and use regex to find
            string pageContents = Data.ReadFromFile_TextReader(tempPage);
            string iconURL = Data.BetweenStrings("<meta property=\"og:image\" content=\"", "\"/>", pageContents);

            //delete temo html file
            System.IO.File.Delete(tempPage);

            return iconURL;
        }


        //Updates the file details from details at the embed link if the file details are absent
        public void GetDetails_FromEmbedLink()
        {
            if (this.location.Contains("liveleak.com"))
            {
                //to be done
            }
            else if (this.location.Contains("youtube.com"))
            {
                GetDetails_FromEmbedLink_Youtube();
            }
            this.Update();
        }

        private void GetDetails_FromEmbedLink_Youtube()
        {
            try
            {
                string externalID = ReturnExternalLinkID(this.location, File.externalLink_youtube);
                string tempPage = LocationPhysical_TempFolder(externalID + ".html");
                string returnMessage = "";

                //download the page and get the file details
                //www.youtube.com/watch?v=PaTaKglYKpo
                SaveFile(this.location, tempPage, ref returnMessage);

                //get page contents
                string pageContents = Data.ReadFromFile_TextReader(tempPage);

                //get title and desciption, tags
                if (this.title == "")
                {
                    this.title = Data.BetweenStrings("<meta name=\"title\" content=\"", "\">", pageContents);
                }
                if (this.description == "")
                {
                    this.description = Data.BetweenStrings("<p id=\"eow-description\" >", "</p>", pageContents);
                }
                if (this.tags == "")
                {
                    this.tags = Data.BetweenStrings("<meta name=\"keywords\" content=\"", "\">", pageContents);
                    this.tags = this.tags.Replace(",", "");
                }

                //delete temp html file
                System.IO.File.Delete(tempPage);
            }
            catch (Exception ex)
            {
                Event.SaveEvent("File.GetDetails_FromEmbedLink_Youtube - error: " + ex.Message.ToString() + " id: " + this.id.ToString(), Event.Type_Error);
            }
        }



        public static void Download_AlbumFromHotNewHipHop(string url, HttpServerUtility server, Page page)
        {
            try
            {
                string tempPage = LocationPhysical_TempFolder(DateTime.Now.ToString("yyMMddhhmmssfff") + ".html");
                string returnMessage = "";

                //download the page and get the file details
                //http://www.hotnewhiphop.com/maino-i-am-who-i-am-hosted-by-dj-green-lantern-and-dj-infamous-mixtape.43284.html
                SaveFile(url, tempPage, ref returnMessage);

                //get page contents
                string pageContents = Data.ReadFromFile_TextReader(tempPage);

                //delete temp html file
                System.IO.File.Delete(tempPage);

                //get title and desciption, tags, artist name
                string title, description, tags, artist, imageURL;

                title = Data.BetweenStrings("<meta name=\"description\" content=\"", "\" />", pageContents).Replace("&amp;", "@");
                imageURL = Data.BetweenStrings("<link rel=\"image_src\" href=\"", "\" />", pageContents);
                description = "";
                artist = Data.BetweenStrings("<title>", " -", pageContents);
                tags = Data.Remove(title, "&amp;", ")", "(", "-") + " " + artist;

                //create file (music album)
                //download thumbnail image (album cover)
                int fileID = 0;
                string fileLocation = "";
                string albumDL = File.UploadFile(null, description, server, page, 9999999, ref fileID, ref fileLocation, true, imageURL);

                //if successful upload, save file
                File file = new File();
                if (albumDL.StartsWith("Uploaded successfully"))
                {
                    file = new File();
                    file.Load(fileID);
                    file.title = title;
                    file.privacy = File.privacy_public;
                    file.allow_comments = true;
                    file.tags = tags;
                    file.fileType = File.fileType_musicAlbum;
                    file.Update();

                    file.CreateIconImage();
                }
                
                //get mp3s from page (title, mp3 location)
                //between bodytext and </td> where not including </div>
                ArrayList al = Data.GetMatchesInPage(pageContents, "title:(\n|.(?!songId:))*");
                if (al.Count == 0)
                {
                    //no mp3s found
                }

                //for each mp3, download and create file with album cover as thumb, and set as reply file to album file
                int i = al.Count;
                string mp3, mp3DL, fileLocation_mp3="";
                int fileID_mp3 = 0;
                while (i > 0)
                {
                    try
                    {
                        //get mp3
                        string mp3_contents = al[i - 1].ToString();

                        //get title and fileurl
                        string mp3_title, mp3_url, mp3_tags;
                        mp3_title = Data.BetweenStrings("title:\"", "\",", mp3_contents).Replace("&amp;", "@") + " by " + artist;
                        mp3_url = Data.BetweenStrings("mp3:\"", "\",", mp3_contents);
                        //if mp3_url contains ? //http://stream.hotnewhiphop.com/song/1328117191_01_intro_prod_by_lacekidd.mp3?e=1328139351&h=a4d575faee0f4c01d0170b0151d7f732
                        //if (mp3_url.Contains("?"))
                        //{
                        //    mp3_url = mp3_url.Substring(0, mp3_url.IndexOf("?"));
                        //}
                        mp3_tags = Data.Remove(mp3_title, "&amp;", ")", "(", "-") + " " + artist;

                        //upload file in reply to album
                        mp3DL = File.UploadFile(null, "", server, page, 9999999, ref fileID_mp3, ref fileLocation_mp3, true, mp3_url);

                        //if successful upload, save file object
                        if (mp3DL.StartsWith("Uploaded successfully"))
                        {
                            //copy album thumb
                            string mp3_image = file.image.Insert(file.image.LastIndexOf("."), fileID_mp3.ToString());
                            System.IO.File.Copy(File.LocationPhysical(file.image), File.LocationPhysical(mp3_image));

                            //set mp3 files details
                            File fileMP3 = new File();
                            fileMP3.Load(fileID_mp3);
                            fileMP3.title = mp3_title;
                            fileMP3.privacy = File.privacy_public;
                            fileMP3.allow_comments = true;
                            fileMP3.tags = mp3_tags;
                            fileMP3.fileType = File.fileType_misc;
                            fileMP3.image = mp3_image;
                            fileMP3.replyToFileID = file.id;
                            fileMP3.replyToCategoryID = File.fileReplyToCategory_File;
                            fileMP3.Update();
                        }
                    }
                    catch (Exception ex)
                    {
                        Event.SaveEvent("File.Download_AlbumFromHotNewHipHop error within while loop: " + ex.Message, Event.Type_Error);
                    }

                    i--;
                }   

            }
            catch (Exception ex)
            {
                Event.SaveEvent("File.Download_AlbumFromHotNewHipHop - error: " + ex.Message.ToString() + " url: " + url, Event.Type_Error);
            }
        }



        public static void CreateIconImagesForAllFiles_OpenThread(HttpApplicationState application)
        {
            Thread thread = new Thread(CreateIconImagesForAllFiles);
            thread.SetApartmentState(ApartmentState.STA);

            application.Add("swfIconThread", thread);
            thread.Start();
        }

        public static void CreateIconImagesForAllFiles_CloseThread(HttpApplicationState application)
        {
            Thread thread = (Thread)application["swfIconThread"];
            thread.Abort();
        }

        public static void CreateIconImagesForAllFiles()
        {
            //create icon image for swf files without image
            int fileID = 0;
            int count = 0;
            while (true)
            {
                //get newest swf file without icon image
                fileID = GetFileWithoutImage();

                if (fileID != 0)
                {
                    //create icon for the file
                    File file = new File();
                    file.Load(fileID);
                    file.CreateIconImage_FromSWF();
                }

                //add delay
                System.Threading.Thread.Sleep(5000);

                //reset fileid
                fileID = 0;

                count++;
            }
        }

        //return a swf file without a icon image
        private static int GetFileWithoutImage()
        {
            DBAccess conn = new DBAccess("file_GetFileWithoutImage");
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return int.Parse(ds.Tables[0].Rows[0][0].ToString());
            }

            return 0;
        }

        public void CreateThumbVideo_FromVideo(string saveFolder)
        {
            //create a thumb video 
            if (ConvertVideo(saveFolder + this.location, saveFolder + this.location + ".9070.flv"))
            {
                this.location_thumb_video_9070 = this.location + ".9070.flv";
                this.fileType = File.fileType_video;
                this.Update();
            }
        }
        private bool ConvertVideo(string srcURL, string destURL)
        {
            //srcURL = srcURL.Replace("/", "\\");
            //destURL = destURL.Replace("/", "\\");

            ////copy source
            //string tempFile = srcURL + ".temp";
            //System.IO.File.Copy(srcURL, tempFile);
            //Event.SaveEvent("copy from: " + srcURL + " to: " + tempFile, Event.Type_System_AutoIconCreation);
            //srcURL = tempFile;

            

            //string ffmpegURL = "~/project/tools/ffmpeg.exe";
            //DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Server.MapPath(ffmpegURL)));
            string ffmpegURL = "c:\\ffmpeg.exe";
            DirectoryInfo directoryInfo = new DirectoryInfo("c:\\");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = ffmpegURL;

            //c:\ffmpeg.exe -i       " -acodec mp3 -ab 64k -ac 2 -ar 44100 -f flv -filter:v yadif -nr 500 -s 640x480 -aspect 4:3 -r 25 -b 650k -me_range 25 -i_qfactor 0.71 -g 500 "c:\Files\Users\4\24\124\124\20120928\bv1106071.mp4conterted-qscale9.flv"
            //c:\ffmpeg.exe -i "     " -f flv "c:\Files\Users\4\24\124\124\20120928\bv1106071.mp4conterted-nooptions.flv"
            startInfo.Arguments = string.Format(" -i \"{0}\" -y -an -s 90x70 -t 60 -c:v libx264 -q:v 25 \"{1}\"", srcURL, destURL);
            startInfo.Arguments = startInfo.Arguments.Replace("/","\\");

            Event.SaveEvent(startInfo.FileName + startInfo.Arguments, Event.Type_System_AutoIconCreation, this.id);
            
            startInfo.WorkingDirectory = directoryInfo.FullName;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = false;

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;

                try
                {
                    process.Start();
                    //StreamReader standardOutput = process.StandardOutput;
                    //StreamWriter standardInput = process.StandardInput;
                    //StreamReader standardError = process.StandardError;
                    //string output = process.StandardOutput.ReadToEnd();
                    if (process.WaitForExit(600000))
                    {
                        if (System.IO.File.Exists(destURL))
                        {
                            return true;
                        }
                    }
                                      
                }
                catch (Exception ex)
                {
                    //delete temp file
                    //System.IO.File.Delete(tempFile);
                    return false;
                }               
                
            }

            //System.IO.File.Delete(tempFile);
            return false;
        }


        private void CreateIconImage_FromSWF()
        {
            //thumbnail location
            string swfScreenShotLocationRelative = "";
            try
            {
                if (this.location.Contains("http://"))
                {
                    swfScreenShotLocationRelative = "embedIcons\\" + this.location.Replace("'", "").Replace("\"", "").Replace("\\", "").Replace("/", "").Replace(":", "").Replace("?", "").Replace("=", "").Replace("&", "").Replace(".", "") + ".jpg";
                }
                else
                {
                    //use file location + sfscreen.jpg
                    //swfScreenShotLocationRelative = this.location.Replace(".swf", "swfscreen.jpg").Replace("'", "").Replace("\"", "").Replace("?", "");

                    //use file folder location with file.id .jpg
                    swfScreenShotLocationRelative = this.location.Replace("'", "").Replace("\"", "").Replace("?", "");
                    swfScreenShotLocationRelative = swfScreenShotLocationRelative.Substring(0, swfScreenShotLocationRelative.LastIndexOf("/"));
                    swfScreenShotLocationRelative = swfScreenShotLocationRelative + "/" + this.id.ToString() + "swfscreen.jpg";
                }


                //create thumbnail
                BrowserThumbnail bt = new BrowserThumbnail();
                bt.swfURL = ConfigurationSettings.AppSettings["serveforthumbnailPath"].ToString() + this.id.ToString();
                bt.swfScreenShotLocationPhysical = File.LocationPhysical(swfScreenShotLocationRelative);

                Thread thread = new Thread(bt.GenerateScreenshotForSWF);
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA - browserthumbnail class doesnt work otherwise
                thread.Start();
                thread.Join();


                //if screenshot exists, create icon
                if (System.IO.File.Exists(File.LocationPhysical(swfScreenShotLocationRelative)))
                {
                    //create icon
                    //this.image = Image.CreateIconImage(swfScreenShotLocationRelative, true);
                    this.Update();

                    //delete screenshot
                    //System.IO.File.Delete(File.LocationPhysical(swfScreenShotLocationRelative));

                    //record that the icon was created
                    Event.SaveEvent("Icon created for swf file", Event.Type_System_AutoIconCreation, this.id);
                }
                else
                {
                    Event.SaveEvent("Icon unable to be created for swf file", Event.Type_System_AutoIconCreation_Failed, this.id);
                }
            }
            catch (Exception ex)
            {
                Event.SaveEvent("Icon unable to be created for swf file - error: " + ex.Message.ToString() + " swfScreenShotLocationRelative: " + swfScreenShotLocationRelative, Event.Type_System_AutoIconCreation_Failed);
            }
        }

        #endregion


        #region Forms

        #region "DataSets"
        /// <summary>
        /// Return suggested swfs
        /// </summary>
        /// <param name="userId"></param>
        public static DataSet GetSuggested(int fileID)
        {
            DBAccess conn = new DBAccess("file_GetSuggested");
            conn.AddParameter("@fileID", fileID);
            return conn.ExecuteReader();
        }
        public static DataSet GetNew()
        {
            DBAccess conn = new DBAccess("file_GetNew");
            return conn.ExecuteReader();
        }

        public static string DisplayThumbVideo(object fileID_object)
        {
            int fileID_int = (int)fileID_object;

            //get file
            Page page = HttpContext.Current.Handler as Page;
            File file = File.Load_FromCache(fileID_int, page);

            //see the thumb video has been created
            if (file.location_thumb_video_9070_exists)
            {
                return "true";
            }
            else
            {
                //open thread to create thumb video
                return "false";
            }
        }


        public static DataSet GetRecentLike()
        {
            DBAccess conn = new DBAccess("file_GetRecentLike");
            return conn.ExecuteReader();
        }

        public static DataSet GetRecentComments()
        {
            DBAccess conn = new DBAccess("file_GetRecentComments");
            return conn.ExecuteReader();
        }


        /// <summary>
        /// Returns random files the user has liked
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataSet GetUserLike(int userID)
        {
            DBAccess conn = new DBAccess("file_GetUserLike");
            conn.AddParameter("@userID", userID);
            return conn.ExecuteReader();
        }

        /// <summary>
        /// Get unpopular file
        /// </summary>
        /// <returns></returns>
        public static int GetUpopular()
        {
            DBAccess conn = new DBAccess("file_GetUnpopular");
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return (int)ds.Tables[0].Rows[0]["ID"];
            }
            return 0;
        }

        public static DataTable GetUpopular_DT()
        {
            DBAccess conn = new DBAccess("file_GetUnpopular");
            DataSet ds = conn.ExecuteReader();
            return ds.Tables[0];
        }

        /// <summary>
        /// Get 4 popular files
        /// </summary>
        /// <returns></returns>
        /// 
        public static DataSet GetPopular(int fileType)
        {
            DBAccess conn = new DBAccess("file_GetPopular");
            conn.AddParameter("@fileType", fileType);
            return conn.ExecuteReader();
        }

        public static DataSet GetVideosWithoutThumbVideo()
        {
            DBAccess conn = new DBAccess("file_GetVideosWithoutThumbVideo");
            return conn.ExecuteReader();
        }

        

        public static DataSet GetPopular_One(int notFileID)
        {
            DBAccess conn = new DBAccess("file_GetPopular_One");
            if (notFileID != 0)
            {
                conn.AddParameter("@notFileID", notFileID);
            }
            return conn.ExecuteReader();
        }

        public static DataSet GetPopular_Many(int fileType)
        {
            return GetPopular_Many(fileType, false);
        }
        /// <summary>
        /// Returns 40 popular files for the file type. Used for browse.aspx
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static DataSet GetPopular_Many(int fileType, bool adult)
        {
            DBAccess conn = new DBAccess("file_GetPopular_Many");
            if (fileType != 0)
            {
                conn.AddParameter("@fileType", fileType);
            }
            if (adult)
            {
                conn.AddParameter("@adult", 1);
            }
            return conn.ExecuteReader();
        }

        /// <summary>
        /// Returns 30. Used for featured files on front page.
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public static DataSet GetPopular_Many_30(int fileType)
        {
            DBAccess conn = new DBAccess("file_GetPopular_Many_30");
            if (fileType != 0)
            {
                conn.AddParameter("@fileType", fileType);
            }
            return conn.ExecuteReader();
        }

        public static DataSet GetBrowseCategories(int fileType)
        {
            DBAccess conn = new DBAccess("file_Browse_GetCategories");
            conn.AddParameter("@fileType", fileType);
            return conn.ExecuteReader();
        }

        public static DataSet GetBrowseCategory_Suggestions(int browseCategoryID)
        {
            DBAccess conn = new DBAccess("file_BrowseCategory_GetSuggestions");
            conn.AddParameter("@browseCategoryID", browseCategoryID);
            return conn.ExecuteReader();
        }
        public static DataSet GetBrowseCategory_Suggestions_Many(int browseCategoryID)
        {
            DBAccess conn = new DBAccess("file_BrowseCategory_GetSuggestions_Many");
            conn.AddParameter("@browseCategoryID", browseCategoryID);
            return conn.ExecuteReader();
        }




        /// <summary>
        /// Return if a file exists with the external ID passed
        /// </summary>
        /// <param name="externalID"></param>
        /// <returns></returns>
        public static bool FileExistsByExternalID(string externalID)
        {
            if (GetFileIDByExternalID(externalID) > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Function returns the file id of file where external id is passed
        /// </summary>
        /// <param name="notFileID"></param>
        /// <returns></returns>
        public static int GetFileIDByExternalID(string externalID)
        {
            DBAccess conn = new DBAccess("file_GetIDByExternalID");
            conn.AddParameter("@value", externalID);
            DataSet ds = conn.ExecuteReader();
            if (ds.Tables[0].Rows.Count > 0)
            {
                return (int)ds.Tables[0].Rows[0][0];
            }
            return 0;
        }


        //returns files replied to another file
        public static DataSet GetReplyFiles(int fileID)
        {
            return GetReplyFiles(fileID, 0);
        }

        //returns files replied to an object or category or combination
        public static DataSet GetReplyFiles(int fileID, int replyToCategoryID)
        {
            //pass only variable that has a value other than 0
            DBAccess conn = new DBAccess("file_GetReplyFiles");
            conn.AddParameter("@fileID", fileID);
            if (replyToCategoryID != 0) { conn.AddParameter("@replyToCategoryID", replyToCategoryID); }
            return conn.ExecuteReader();
        }

        public static DataSet GetReplyFiles(int fileID, int replyToCategoryID, int recordsToReturn)
        {
            //return only the top # of records
            DataSet ds = GetReplyFiles(fileID, replyToCategoryID);

            //create new datatable
            DataTable dt = ds.Tables[0];
            DataTable dtn = dt.Clone();
            int rowCount = dt.Rows.Count;
            for (int i = 0; i < recordsToReturn && i<rowCount; i++)
            {
                dtn.ImportRow(dt.Rows[i]);
            }
            
            //replace existing datatable with new
            ds.Tables.Remove(dt);
            ds.Tables.Add(dtn);

            return ds;
        }

        /// <summary>
        /// Returns featured files
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataSet Search_Featured()
        {
            return Search_Featured(File.fileType_all);
        }
        public static DataSet Search_Featured(int fileType)
        {
            DBAccess conn = new DBAccess("file_Search_Featured");
            conn.AddParameter("@fileType", fileType);
            return conn.ExecuteReader();
        }


        /// <summary>
        /// Get recent FLA files
        /// </summary>
        /// <returns></returns>
        public static DataSet Search_FLA()
        {
            DBAccess conn = new DBAccess("file_Search_FLA");
            return conn.ExecuteReader();
        }

        /// <summary>
        /// Returns files based on the values passed as tags
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static DataSet Search(string values)
        {
            return Search(values, File.fileType_all);
        }
        public static DataSet Search(string values, int fileType)
        {
            DBAccess conn = new DBAccess("file_Search");
            conn.AddParameter("@fileType", fileType);

            //split values by " "
            values = values.Trim();
            string[] valuesSplit = values.Split(' ');

            //for each word
            int count = valuesSplit.Length - 1;
            int valueCount = 1;
            while (count >= 0)
            {
                //for each word, pass to the stored procedure as a value 
                if (valuesSplit[count] != "")
                {
                    conn.AddParameter("@value" + valueCount.ToString(), valuesSplit[count].ToString());
                    valueCount++;
                }

                count--;

                //if hit maximum number of search words (6), exit loop
                if (valueCount == 6)
                {
                    count = -1;
                }
            }


            //sp returns files order by those with most matches
            return conn.ExecuteReader();
        }

        public DataSet GetFileTags()
        {
            DBAccess conn = new DBAccess("file_GetTags");
            conn.AddParameter("@fileID", this.id);
            return conn.ExecuteReader();
        }


        public static DataSet GetFilesForUser(int UserID, int ProjectID, bool publicFilesOnly)
        {
            DBAccess conn = new DBAccess("[file_GetUnderUser]");
            conn.AddParameter("@userID", UserID);
            if (ProjectID != 0) { conn.AddParameter("@projectID", ProjectID); }
            conn.AddParameter("@publicFilesOnly", publicFilesOnly);
            return conn.ExecuteReader();
        }


        public static string DisplayImagePath(object path)
        {
            string imageValue = path.ToString();

            //if image icon existing
            if (imageValue != "")
            {
                return "/" + File.uploadedFilesDirectory + "/" + imageValue;
            }
            else
            {
                //else return generic image
                return "/images/fileIcon_unknown.png";
            }
        }

        public static string DisplayThumbImageFromFile(object filePath, int maxWidth)
        {
            string path_file = "/" + filePath.ToString();

            return "/" + File.uploadedFilesDirectory; // + Image.CreateIconImage(path_file, false, 0, maxWidth); 
        }
        #endregion

        #endregion


        #region "Upload"
        public static string SaveFolder()
        {
            //string rootDirectory = ConfigurationSettings.AppSettings["fileSaveDirectoryPhysicalPath"];  //C:\inetpub\wwwroot\megasssAJAX\files\
            ////HttpContext.Current.Server.MapPath(uploadedFilesDirectory) + "\\";
            //return rootDirectory; // + uploadedFilesDirectory + "\\";
            string rootDirectoryPhysicalPath = ConfigurationSettings.AppSettings["rootDirectoryPhysicalPath"];
            return rootDirectoryPhysicalPath + uploadedFilesDirectory + "\\";
        }
        public static string SaveFolder(HttpServerUtility server)
        {
            //place based on date
            //return server.MapPath(uploadedFilesDirectory) + "\\";
            return SaveFolder();
        }

        static bool UploadFile_Browse(Brettle.Web.NeatUpload.InputFile File1, HttpServerUtility server, ref string returnMessage, ref string fileLocation, float maxFileSize, int userID, ref string strFileName, ref float fileSize)
        {
            //ATTEMPT TO UPLOAD
            if (File1.FileName != null)
            {
                fileSize = File1.ContentLength;

                //check the the file type is allowed
                string ext = File1.FileName.Substring(File1.FileName.LastIndexOf(".") + 1, (File1.FileName.Length - File1.FileName.LastIndexOf(".")) - 1);
                if (!AllowedFileExtension(ext))
                {
                    returnMessage = "Extension " + ext + " is not allowed.";
                    return false;
                }

                //check that the user has space left to upload
                if (GetUserSizeTotal(userID) + fileSize > defaultMaxTotalAmount)
                {
                    returnMessage = "Insufficient space remaining.";
                    return false;
                }
                else if (fileSize > maxFileSize)
                {
                    returnMessage = "File size exceeds maximum allowed.";
                    Event.SaveEvent("File size exceeds maximum allowed attempt.", Event.Type_System);

                    return false;
                }
                else
                {
                    string tempFile = "";
                    string savePath = "";

                    strFileName = File1.FileName;
                    strFileName = Regex.Replace(strFileName, "[^a-zA-Z0-9_ \\.]", "").ToLower().Trim(); //remove all but these chars

                    strFileName = strFileName.Substring(strFileName.LastIndexOf("\\") + 1);
                    try
                    {
                        //check that the folders exist
                        string directories;
                        if (userID == 0)
                        {
                            directories = DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                        }
                        else
                        {
                            //directories = "Users\\" + userID.ToString().Substring(userID.ToString().Length - 1, 1) + "\\" + userID.ToString().Substring(userID.ToString().Length - 2, 2) + "\\" + userID.ToString().Substring(userID.ToString().Length - 3, 3) + "\\" + userID.ToString() + "\\";
                            directories = userID.ToString() + "\\" + Data.CreateRandomString(5) + "\\";
                        }
                        string folder = SaveFolder(server) + directories;
                        if (!System.IO.Directory.Exists(folder))
                        {
                            System.IO.Directory.CreateDirectory(folder);
                        }

                        //create the save location
                        //fileLocation = directories + Guid.NewGuid() + ext; //strFileName.Substring(strFileName.LastIndexOf("."), (strFileName.Length - strFileName.LastIndexOf(".")));
                        //string savePath = SaveFolder(server) + fileLocation;

                        strFileName = FreeFileLocation(directories, strFileName, server);
                        fileLocation = directories + strFileName;
                        savePath = SaveFolder(server) + fileLocation;

                        tempFile = SaveFolder(server) + "Temp\\" + strFileName;
                        File1.MoveTo(tempFile, MoveToOptions.Overwrite);

                        //copy the file to ensure it gets the correct permissions
                        //string dest = savePath.Insert(savePath.LastIndexOf("."), "1");
                        System.IO.File.Copy(tempFile, savePath);
                        System.IO.File.Delete(tempFile);

                        returnMessage = "Uploaded successfully: " + strFileName;
                        return true;
                    }
                    catch (Exception err)
                    {
                        QuantumLibrary.SystemError.Record(err);
                        Event.SaveEvent("file.cs line 1244 Error: " + err.Message + " tempFile: " + tempFile + " savePath: " + savePath, Event.Type_Error);

                        returnMessage = "Failed Uploading " + strFileName + " <br /> Error: " + err.Message + " tempFile: " + tempFile + " savePath: " + savePath;
                        return false;
                    }
                }
            }
            else
            {
                returnMessage = "File not selected.";
                return false;
            }
        }


        private static string FreeFileLocation(string directories, string strFileName, HttpServerUtility server)
        {
            //create save path
            string savePath = SaveFolder(server) + directories + strFileName;

            //check that file location is free
            while (System.IO.File.Exists(savePath))
            {
                //if not, add (1) and check again
                strFileName = strFileName.Insert(strFileName.LastIndexOf("."), "(1)");

                //recreate save path
                savePath = SaveFolder(server) + directories + strFileName;
            }

            return strFileName;
        }

        private static bool SaveFile(string fileURL, string saveLocation, ref string returnMessage)
        {
            try
            {
                CookieAwareWebClient client = new CookieAwareWebClient();
                client.Headers.Add("user-agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.10) Gecko/20100914 Firefox/3.6.10");

                //allempt to create session on server to download from
                try
                {
                    client.DownloadFile(fileURL.Substring(0, fileURL.IndexOf("/", 7)), saveLocation + "temp");
                    System.IO.File.Delete(saveLocation + "temp");
                }
                catch
                {
                }

                client.DownloadFile(fileURL, saveLocation);
                Thread.Sleep(2000);

                return true;
            }
            catch (Exception err)
            {
                returnMessage = "Failed Downloading " + fileURL + " <br /> Error: " + err.Message;
                return false;
            }
        }

        static bool UploadFile_URL(string url, HttpServerUtility server, ref string returnMessage, ref string fileLocation, float maxFileSize, int userID, ref string strFileName, ref float fileSize)
        {
            try
            {
                //ATTEMPT TO UPLOAD

                if (url != "")
                {
                    //download the file
                    //check that the folders exist
                    string directories;
                    if (userID == 0)
                    {
                        directories = DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                    }
                    else
                    {
                        directories = "Users\\" + userID.ToString().Substring(userID.ToString().Length - 1, 1) + "\\" + userID.ToString().Substring(userID.ToString().Length - 2, 2) + "\\" + userID.ToString().Substring(userID.ToString().Length - 3, 3) + "\\" + userID.ToString() + "\\";
                    }
                    string folder = SaveFolder(server) + directories;
                    if (!System.IO.Directory.Exists(folder))
                    {
                        System.IO.Directory.CreateDirectory(folder);
                    }

                    //create the save location
                    fileLocation = directories + Guid.NewGuid() + url.Substring(url.LastIndexOf("."), (url.Length - url.LastIndexOf(".")));
                    //if fileLocation contains ? //http://stream.hotnewhiphop.com/song/1328117191_01_intro_prod_by_lacekidd.mp3?e=1328139351&h=a4d575faee0f4c01d0170b0151d7f732
                    if (fileLocation.Contains("?"))
                    {
                        fileLocation = fileLocation.Substring(0, fileLocation.IndexOf("?"));
                    }

                    //file name
                    strFileName = url.Substring(url.LastIndexOf("/") + 1, (url.Length - url.LastIndexOf("/") - 1));
                    if (strFileName.Contains("?"))
                    {
                        strFileName = strFileName.Substring(0, strFileName.IndexOf("?"));
                    }

                    string savePath = SaveFolder(server) + fileLocation;
                    if (!SaveFile(url, savePath, ref returnMessage))
                    {
                        return false;
                    }


                    //get file info
                    System.IO.FileInfo fi = new System.IO.FileInfo(savePath);
                    fileSize = float.Parse(fi.Length.ToString());

                    //check the the file type is allowed
                    if (!AllowedFileExtension(fi.Extension))
                    {
                        returnMessage = "Extension " + fi.Extension + " is not allowed.";

                        //delete file
                        System.IO.File.Delete(savePath);

                        return false;
                    }

                    //check that the user has space left to upload
                    if (GetUserSizeTotal(userID) + fileSize > defaultMaxTotalAmount)
                    {
                        returnMessage = "Insufficient space remaining.";

                        //delete file
                        System.IO.File.Delete(savePath);

                        return false;
                    }
                    else if (fileSize > maxFileSize)
                    {
                        returnMessage = "File size exceeds maximum allowed.";

                        //delete file
                        System.IO.File.Delete(savePath);

                        return false;
                    }
                    else
                    {
                        returnMessage = "Uploaded successfully: " + strFileName;
                        return true;
                    }
                }
                else
                {
                    returnMessage = "URL not selected.";
                    return false;
                }
            }
            catch (Exception err)
            {
                returnMessage = "Failed Uploading " + strFileName + " <br /> Error: " + err.Message;
                return false;
            }
        }

        public static bool AllowedFileExtension(string ext)
        {
            //allow everything except asp aspx aspx.cs
            if (ext == "asp" || ext == "aspx" || ext == "cs" ||ext == "exe")
            {
                return false;
            }
            else
            {
                return true;
            }


            ////if ext passed is one of the allowed extensions, return true
            //ext = ext.Trim().ToLower().Replace(".", "");
            //if (ext == "swf" || ext == "xml" || ext == "jpg" || ext == "jpeg" || ext == "png" || ext == "gif" || ext == "bmp" || ext == "mov" || ext == "mpg4" || ext == "avi" || ext == "txt" || ext == "flv" || ext == "fla" || ext == "xap" || ext == "mp3")
            //{
            //    return true;
            //}
            //else
            //{
            //    //return false if the ext is not allowed
            //    return false;
            //}
        }

        public static bool FileExtension_Image(string ext)
        {
            //if ext passed is image, return true
            ext = ext.Trim().ToLower();
            if (ext == "jpg" || ext == "jpeg" || ext == "png" || ext == "gif" || ext == "bmp")
            {
                return true;
            }
            else
            {
                //return false if the ext is not an image
                return false;
            }
        }

        public static bool FileExtension_Video(string ext)
        {
            //if ext passed is video, return true
            ext = ext.Trim().ToLower();
            if (ext == "mp4" || ext == "flv")
            {
                return true;
            }
            else
            {
                //return false if the ext is not a video
                return false;
            }
        }

        //upload a file
        public static string UploadFile(Brettle.Web.NeatUpload.InputFile File1, string description, HttpServerUtility server, Page page, float maxFileSize, ref int fileID, ref string fileLocation, bool saveFileObjectInDatabase, string downloadFromURL)
        {
            int id = 0;
            string returnMessage = "";
            string strFileName = "";
            float fileSize = 0;
            int userID = GoalUser.CurrentUserId(page);
            if (downloadFromURL != "")
            {
                if (!UploadFile_URL(downloadFromURL, server, ref returnMessage, ref fileLocation, maxFileSize, userID, ref strFileName, ref fileSize))
                {
                    return returnMessage;
                }
            }
            else if (File1.FileName != null)
            {
                if (!UploadFile_Browse(File1, server, ref returnMessage, ref fileLocation, maxFileSize, userID, ref strFileName, ref fileSize))
                {
                    return returnMessage;
                }
            }
            else
            {

                return "File not selected.";
            }

            //SAVE FILE OBJECT

            if (saveFileObjectInDatabase)
            {
                //create new file
                File file = new File();
                file.userID = userID;
                file.fileName = strFileName;
                file.ext = strFileName.Substring(strFileName.LastIndexOf(".") + 1, (strFileName.Length - strFileName.LastIndexOf(".")) - 1);
                file.fileSize = fileSize;
                file.Create();
                file.description = description;
                file.location = fileLocation.Replace("\\", "/");
                file.Update();

                fileID = file.id;

                file.CreateIconImage();
            }

            return returnMessage;
        }


        public static bool DownloadFile(int fileId, HttpResponse response, HttpServerUtility server)
        {
            return DownloadFile(fileId, response, server, true);
        }

        public static bool DownloadFile(int fileId, HttpResponse response, HttpServerUtility server, bool streamIfPossible)
        {
            //get file object
            File file = new File();
            file.Load(fileId);

            return DownloadFile(file, response, server, streamIfPossible);
        }

        public static bool DownloadFile(File file, HttpResponse response, HttpServerUtility server, bool streamIfPossible)
        {
            try
            {
                //get file and send to user
                string FilePath = SaveFolder(server) + file.location;

                if (System.IO.File.Exists(FilePath))
                {
                    System.IO.FileInfo TargetFile = new System.IO.FileInfo(FilePath);
                    response.Clear();
                    response.AddHeader("Content-Length", TargetFile.Length.ToString());


                    //set correct content type
                    if (!streamIfPossible)
                    {
                        //popup dialogue box
                        response.AddHeader("Content-Disposition", "attachment; filename=" + file.fileName.Replace(" ", "_")); //TargetFile.Name
                        response.ContentType = "application/octet-stream";
                    }
                    else if (file.ext == "swf")
                    {
                        response.ContentType = "application/x-shockwave-flash";
                        if (file.fileName.Trim() == "")
                        {
                            response.AddHeader("Content-disposition", "inline;filename=" + file.id.ToString() + "file.swf");
                        }
                        else
                        {
                            response.AddHeader("Content-disposition", "inline;filename=" + file.fileName);
                        }

                    }
                    else if (file.ext == "xap")
                    {
                        response.ContentType = "application/x-silverlight-app";
                    }
                    else if (file.ext == "mp3")
                    {
                        response.ContentType = "audio/mpeg3";
                    }
                    else if (file.ext == "png")
                    {
                        response.ContentType = "image/png";
                    }
                    else if (file.ext == "bmp")
                    {
                        response.ContentType = "image/bmp";
                    }
                    else if (file.ext == "jpg")
                    {
                        response.ContentType = "image/jpeg";
                    }
                    else if (file.ext == "jpeg")
                    {
                        response.ContentType = "image/jpeg";
                    }
                    else if (file.ext == "gif")
                    {
                        response.ContentType = "image/gif";
                    }
                    else
                    {
                        //popup dialogue box
                        response.AddHeader("Content-Disposition", "attachment; filename=" + file.fileName.Replace(" ", "_")); //TargetFile.Name
                        response.ContentType = "application/octet-stream";
                    }

                    response.WriteFile(TargetFile.FullName);
                    response.End();
                    return true;
                }
                else
                {
                    //Event.SaveEvent("File.DownloadFile() file doesn't exist. FileID: " + fileId.ToString(), Event.Type_Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //Event.SaveEvent("File.DownloadFile() - error: " + ex.Message.ToString(), Event.Type_Error);
                return false;
            }
        }

        public static float GetUserSizeTotal(int userID)
        {
            if (userID == 0)
            {
                return 0;
            }

            DBAccess conn = new DBAccess("file_GetUserSizeTotal");
            conn.AddParameter("@userID", userID);

            float userSizeTotal = 0;

            //load details into class
            DataView dv = ((DataSet)conn.ExecuteReader()).Tables[0].DefaultView;
            foreach (DataRowView dr in dv)
            {
                userSizeTotal = Data.validFloat(dr["userSizeTotal"].ToString());
            }

            return userSizeTotal;
        }
        #endregion

        /// <summary>
        /// Passed an external link to a site (youtube / liveleak etc) and returns the id for the site
        /// </summary>
        /// <param name="link"></param>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public static string externalLink_liveLeakI = "liveleak.com/view?i=";
        public static string externalLink_liveLeakE = "liveleak.com/e/";
        public static string externalLink_youtube = "youtube.com/watch?v=";
        public static string ReturnExternalLinkID(string link, string siteName)
        {
            //remove domain
            string returnLink = link.Replace("www.", "").Replace("http://", "").Replace(siteName, "");

            //remove anything after the ID (&)
            if (returnLink.Contains("&"))
            {
                int andLocation = returnLink.IndexOf("&");
                return returnLink.Substring(0, andLocation);
            }
            else
            {
                return returnLink;
            }
        }

        /// <summary>
        /// Method returns an array list of strings in a text that match the regular expression
        /// </summary>
        /// <param name="InputText"></param>
        /// <param name="regEx"></param>
        /// <returns></returns>
        public static ArrayList GetMatchesInPage(string inputText, string regEx)
        {
            //do regex
            Regex exp = new Regex(regEx, RegexOptions.IgnoreCase);
            MatchCollection MatchList = exp.Matches(inputText);
            ArrayList al = new ArrayList();

            //add values that match the regex to the array list
            int i = MatchList.Count;
            while (i > 0)
            {
                Match match = MatchList[i - 1];
                al.Add(match);
                i--;
            }

            return al;
        }

        public static string ReplaceMatchesInPage(string inputText, string regEx, string replaceText)
        {
            //do regex
            Regex exp = new Regex(regEx, RegexOptions.IgnoreCase);            
            return exp.Replace(inputText, replaceText);
        }


        public static void WriteToFile(string file, string line)
        {
            StreamWriter SW;
            SW = System.IO.File.AppendText(file);
            SW.WriteLine(line);
            SW.Close();
        }   
    }
}