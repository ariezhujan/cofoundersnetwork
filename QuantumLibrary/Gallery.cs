using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace QuantumLibrary
{
    public class Gallery
    {
        public int ID = 0;
        public static void AddFile(int fileID, int galleryID)
        {
            DBAccess conn = new DBAccess("gallery_AddFile");
            conn.AddParameter("@fileID", fileID);
            conn.AddParameter("@fileId_Gallery", galleryID);

            conn.ExecuteScalar();
        }

        public static DataSet GetFiles(int galleryID)
        {
            DBAccess conn = new DBAccess("gallery_GetFiles");
            conn.AddParameter("@fileId_Gallery", galleryID);
            return conn.ExecuteReader();
        }
    }
}
