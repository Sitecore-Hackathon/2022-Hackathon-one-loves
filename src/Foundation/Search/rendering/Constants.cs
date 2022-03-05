using System;

namespace Hackathon.Foundation.Search
{
    public class Constants
    {
        public const string Path = "_path";
        public const string Template = "_template";
        public const string Language = "_language";

        public static Guid AllLocationsId = new Guid("BF570EE0-FCBE-4736-8572-D5F80968507D");

        public class BlogPostConstants
        {
            public const string SortOrder = "sortorder_tl";
            public const string TagsId = "tags_sm";
            public const string TagsName = "tags_titles_sm";
            public const string AuthorId = "author_sm";
            public const string BlogPostText = "postbody_t";
        }

        public class TeamDetailConstants
        {
            public const string Name = "name_t";
            public const string Surname = "surname_t";
            public const string LocationId = "location_sm";
            public const string LocationTitle = "location_title_s";
            public const string PositionId = "position_sm";
            public const string PositionTitle = "position_title_team_s";
            public const string Bio = "bio_t";
        }

        public class JobDetailConstants
        {
            public const string Title = "title_t";
            public const string LocationIds = "locations_sm";
            public const string LocationTitles = "locations_titles_sm";
            public const string PositionId = "position_sm";
            public const string PositionTitle = "position_title_job_s";
        }
    }
}
