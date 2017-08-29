using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.Services
{
    public class TextService : BaseService
    {
        #region Declaration
        public TextService(ApplicationDbContext db)
        {
            this.db = db;
        }
        #endregion

        private static Dictionary<string, string> _dictionary;
        public static Dictionary<string, string> SystemTextDictionary
        {
            get { return _dictionary; }
            set { _dictionary = value; }
        }
        public void InitSystemTextDictionary()
        {
            var systemTexts = db.SystemTexts.OrderBy(x => x.Identifier).ToList();

            _dictionary = new Dictionary<string, string>();
            foreach (SystemText text in systemTexts)
            {
                string dictionaryKey = text.Identifier;
                if (!_dictionary.ContainsKey(dictionaryKey))
                    _dictionary.Add(dictionaryKey, text.TextEng);
            }
        }

        public string Text(string identifier, string defaultText)
        {
            if (SystemTextDictionary == null)
                InitSystemTextDictionary();

            var text = SystemTextDictionary != null && SystemTextDictionary.ContainsKey(identifier) ? SystemTextDictionary[identifier] : null;

            if (text != null)
                return text;

            var newSystemText = new SystemText
            {
                Identifier = identifier,
                TextEng = defaultText
            };
            try
            {
                db.SystemTexts.Add(newSystemText);
                db.SaveChanges();

                SystemTextDictionary = null;
                HttpContext.Current.Application["SystemTextsAll"] = GetSystemTexts();
            }
            catch (Exception ex)
            {
                // LogHelper.LogError(ex);
            }
            return newSystemText.TextEng;
        }

        public List<SystemText> GetSystemTexts()
        {
            return db.SystemTexts.OrderByDescending(x => x.SystemTextId).ToList();
        }

        //public IPagedList<SystemText> GetSystemTexts(string text, int page = 1)
        //{
        //    const int pageSize = 10;
        //    if (text != null)
        //    {
        //        return db.SystemTexts.Where(x => x.Identifier.Contains(text) || x.Text.Contains(text)).OrderByDescending(x => x.SystemTextId).ToPagedList(page, pageSize);
        //    }
        //    return db.SystemTexts.OrderByDescending(x => x.SystemTextId).ToPagedList(page, pageSize);
        //}

        public bool EditSystemTexts(int id, string text)
        {
            var systemText = db.SystemTexts.FirstOrDefault(x => x.SystemTextId == id);
            if (text != null)
            {
                if (systemText != null) systemText.TextEng = text;
                db.SaveChanges();
                SystemTextDictionary = null;
                HttpContext.Current.Application["SystemTextsAll"] = GetSystemTexts();
                return true;
            }
            return false;
        }
    }
}