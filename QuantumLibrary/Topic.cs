using System;
using System.Data;

namespace QuantumLibrary
{
    public class Topic
    {
        public int topicid { get; private set; }
        public string type { get; private set; }
        public string topic { get; private set; }
        public int limit_propertyid { get; private set; }
        public string limit_condition { get; private set; }
        public string limit_value { get; private set; }
        public string limit_value_type { get; private set; }
        public string Condition_Video_Search { get; private set; }
        public string value_string { get; private set; }
        public decimal value_decimal { get; private set; }
        public int value_int { get; private set; }
        public DateTime value_date { get; private set; }
        public int value_tagid { get; private set; }

        public Topic(DataRowView dr)
        {
            topicid = Data.validInt(dr["topicid"].ToString());
            type = dr["type"].ToString();
            topic = dr["topic"].ToString();
            limit_propertyid = Data.validInt(dr["limit_propertyid"].ToString());
            limit_condition = dr["limit_condition"].ToString();
            limit_value = dr["limit_value"].ToString();
            limit_value_type = dr["limit_value_type"].ToString();
            Condition_Video_Search = dr["Condition_Video_Search"].ToString();
            value_string = dr["value_string"].ToString();
            value_decimal = Data.validDecimal(dr["value_decimal"].ToString()); 
            value_int = Data.validInt(dr["value_int"].ToString());
            value_date = Data.validDateTime(dr["value_date"].ToString()); 
            value_tagid = Data.validInt(dr["value_tagid"].ToString());
        }

        public bool ConditionsPassed()
        {
            //if no limiting condition
            if (limit_condition == "") { return true; }

            //for null checks
            if (limit_value == "null")
            {
                if (limit_value_type == "date" && limit_condition == "equal to") { if (value_date == Data.defaultDateTime()) { return true; } }
                else if (limit_value_type == "date" && limit_condition == "not equal to") { if (value_date != Data.defaultDateTime()) { return true; } }
            }

            //establish limit value. e.g. The date the tag's statement must be greater than.
            decimal limit_value_decimal = 0;
            DateTime limit_value_date = new DateTime();
            switch (limit_value_type)
            {
                case "date":
                    if (!DateTime.TryParse(limit_value, out limit_value_date)) { return false; };
                    break;
                case "decimal":
                    if (!decimal.TryParse(limit_value, out limit_value_decimal)) { return false; };
                    break;
            }

            //checks the conditions. e.g. If the tag's statement date is greater than the limit condition. 
            //e.g. Only get videos for interviews of people if they were born after 1940.
            if (limit_value_type == "date" && limit_condition == "greater than") {if (value_date >= limit_value_date) { return true; } }
            else if (limit_value_type == "date" && limit_condition == "less than") { if (value_date <= limit_value_date) { return true; } }
            else if (limit_value_type == "date" && limit_condition == "equal to") { if (value_date == limit_value_date) { return true; } }
            else if (limit_value_type == "date" && limit_condition == "not equal to") { if (value_date != limit_value_date) { return true; } }

            return false;
        }
    }
}
