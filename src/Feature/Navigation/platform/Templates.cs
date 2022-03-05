using Sitecore.Data;

namespace Hackathon.Feature.Navigation
{
  public static class Templates
  {
        public static class NavigationItem
        {
            public static readonly ID Id = new ID("{C231FBB4-DCDB-4708-99BC-94760F222CC5}");
            public static class Fields
            {
                public static readonly ID NavigationTitle = new ID("{32CFF90D-4FDF-4402-A364-21199E88753D}");
            }
        }

        public static class NavigationRoot
        {
            public static readonly ID Id = new ID("{D7F870BC-89D8-4F17-95EC-59ACFD7DA05C}");

            public static class Fields
            {
                public static readonly ID HeaderLogo = new ID("{FEE16E6B-0823-44FB-ACD2-F56DB2011AA3}");
            }
        }

        public static class Footer
        {
            //public static class Fields
            //{
            //    public static readonly ID EmailText = new ID("{47B6A806-A9DC-4586-82AD-0ACFE3AA9D26}");
            //    public static readonly ID Email = new ID("{BC10D7D3-87A5-47FF-869C-F491CB7BE104}");
            //    public static readonly ID SocialLinksText = new ID("{54EE9203-2A42-4BDF-A6BB-87275D960179}");
            //    public static readonly ID Copyright = new ID("{500FBE20-2A96-489E-9226-91B86C0A29C5}");
            //}
        }

        public static class FooterLinkFolder
        {
            public static readonly ID Id = new ID("{28296EB4-E9E4-4AB3-B1F1-0494BA7DE92C}");
        }

        public static class MainNavigation
        {
            public static readonly ID Id = new ID("{7178CC23-F74E-414C-9A9B-5351DD6F6911}");
        }

        public static class NavigationLink
        {
            public static readonly ID Id = new ID("{F3D92634-0B9B-48BD-B7A4-F673F38746D5}");
            //public static class Fields
            //{
            //    public static readonly ID Link = new ID("{48B75AF3-7268-4A1F-A947-B45725845048}");
            //}
        }

        public static class SocialMediaFolder
        {
            public static readonly ID Id = new ID("{52BC4A5C-12EA-4048-A98C-5FDB02386486}");
        }

        public static class SocialMediaItem
        {
            public static readonly ID Id = new ID("{D45C8E03-5D1E-426A-9F78-834A143AAB76}");

            //public static class Fields
            //{
            //    public static readonly ID Icon = new ID("{014400FB-D837-4400-9607-7A1C508130D0}");
            //    public static readonly ID Link = new ID("{E45470D6-9388-4ACB-8B1E-BBDB94A52EE8}");
            //}
        }
    }
}