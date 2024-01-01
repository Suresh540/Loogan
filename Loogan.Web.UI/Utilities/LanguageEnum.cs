namespace Loogan.Web.UI.Utilities
{
    public enum LanguageEnum
    {
        enUS = 1,
        frFR = 2,
    }

    public static class LanguageSelection
    {
        public static int GetLanguageId(string languageName)
        {
            if (languageName.Replace("-","").ToUpper().Contains(LanguageEnum.enUS.ToString().ToUpper()))
            {
                return (int)LanguageEnum.enUS;
            }
            return (int)LanguageEnum.frFR;
        }
    }
}
