using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using SIPProvider.Encryption;

namespace SIPProvider.XmlProvider
{
    public class XmlFile
    {
        // Fields
        private string m_rootName = "profile";
        public string FileName { get; private set; }
        XmlDocument Document;
        public bool UseEncryption { get; private set; }
        private string EncryptionKey = "ashrafco";
        public XmlFile(string fileName, bool UseEncryption) 
        {
            this.UseEncryption = UseEncryption;
            this.FileName = fileName;
            Document = new XmlDocument();
            try
            {
                
                if (File.Exists(fileName))
                {
                    if (!UseEncryption) Document.Load(fileName);
                    else
                    {
                        string x = EncryptDecrypt.DecryptFile(fileName, EncryptionKey) + "";
                        Document.LoadXml(x);
                    }
                }
            }
            catch { }
        }

        /// <summary>
        ///   Retrieves the XPath string used for retrieving a section from the XML file. </summary>
        /// <returns>
        ///   An XPath string. </returns>
        /// <seealso cref="GetEntryPath" />
        private string GetSectionsPath(string section)
        {
            return "section[@name=\"" + section + "\"]";
        }

        /// <summary>
        ///   Retrieves the XPath string used for retrieving an entry from the XML file. </summary>
        /// <returns>
        ///   An XPath string. </returns>
        /// <seealso cref="GetSectionsPath" />
        private string GetEntryPath(string entry)
        {
            return "entry[@name=\"" + entry + "\"]";
        }

        public string RootName
        {
            get { return m_rootName; }
            set { m_rootName = value.Trim(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="entry"></param>
        /// <param name="valueString">If the value is null, remove the entry</param>
        public bool SetValue(string section, string entry, string valueString)
        {
            try
            {
                section = section.Trim(); entry = entry.Trim();
                // If the value is null, remove the entry
                if (valueString == null)
                {
                    RemoveEntry(section, entry);
                    return false;
                }

                if (Document.DocumentElement == null)
                    Document.AppendChild(Document.CreateElement(RootName));

                XmlElement root = Document.DocumentElement;
                // Get the section element and add it if it's not there
                XmlNode sectionNode = root.SelectSingleNode(GetSectionsPath(section));
                if (sectionNode == null)
                {
                    XmlElement element = Document.CreateElement("section");
                    XmlAttribute attribute = Document.CreateAttribute("name");
                    attribute.Value = section;
                    element.Attributes.Append(attribute);
                    sectionNode = root.AppendChild(element);
                }

                // Get the entry element and add it if it's not there
                XmlNode entryNode = sectionNode.SelectSingleNode(GetEntryPath(entry));
                if (entryNode == null)
                {
                    XmlElement element = Document.CreateElement("entry");
                    XmlAttribute attribute = Document.CreateAttribute("name");
                    attribute.Value = entry;
                    element.Attributes.Append(attribute);
                    entryNode = sectionNode.AppendChild(element);
                }

                // Add the value and save the file
                entryNode.InnerText = valueString;
                return true;
            }
            catch { return false; }
        }

        public void SaveBackUp(string backUpFile)
        {
            Document.Save(backUpFile);
        }

        public bool SaveDocument()
        {
            try
            {
                if (!UseEncryption) Document.Save(FileName);
                else EncryptDecrypt.EncryptString(Document.OuterXml, FileName, EncryptionKey);
                return true;
            }
            catch { return false; }
        }

        public string GetValue(string section, string entry)
        {
            try
            {
                section = section.Trim(); entry = entry.Trim();
                XmlElement root = Document.DocumentElement;

                XmlNode entryNode = root.SelectSingleNode(GetSectionsPath(section) + "/" + GetEntryPath(entry));
                return entryNode.InnerText;
            }
            catch { return null; }
        }

    
        public bool RemoveEntry(string section, string entry)
        {
            try
            {
                section = section.Trim(); entry = entry.Trim();
                // Get the entry's node, if it exists
                XmlElement root = Document.DocumentElement;
                XmlNode entryNode = root.SelectSingleNode(GetSectionsPath(section) + "/" + GetEntryPath(entry));
                if (entryNode == null) return false;

                entryNode.ParentNode.RemoveChild(entryNode);
                return true;
            }
            catch { return false; }
        }
        
        /// <summary>
        /// Remove all data from file
        /// </summary>
        public void ClearFile()
        {
            try { Document.RemoveAll(); }
            catch { }
        }

        public bool RemoveSection(string section)
        {
            try
            {
                section = section.Trim();
                // Get the root node, if it exists
                XmlElement root = Document.DocumentElement;

                // Get the section's node, if it exists
                XmlNode sectionNode = root.SelectSingleNode(GetSectionsPath(section));
                if (sectionNode == null) return false;

                root.RemoveChild(sectionNode);
                 return true;
            }
            catch { return false; }
        }

        public List<string> GetEntryNames(string section)
        {
            
            List<string> result = new List<string>();
            try
            {
                section = section.Trim();
                XmlElement root = Document.DocumentElement;
                // Get the entry nodes
                XmlNodeList entryNodes = root.SelectNodes(GetSectionsPath(section) + "/entry[@name]");

                foreach (XmlNode node in entryNodes)
                    result.Add(node.Attributes["name"].Value);
            }
            catch { }
            return result;
        }

        

        public List<string> GetSectionNames()
        {
            List<string> result = new List<string>();
            try
            {
                // Get the root node, if it exists
                XmlElement root = Document.DocumentElement;
                // Get the section nodes
                XmlNodeList sectionNodes = root.SelectNodes("section[@name]");

                foreach (XmlNode node in sectionNodes)
                    result.Add(node.Attributes["name"].Value);
            }
            catch { }
            return result;
        }
         
        /// <summary>
        /// Get the EntryValues
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetEntryValues(string section)
        {
            section = section.Trim();
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                XmlElement root = Document.DocumentElement;
                // Get the entry nodes
                XmlNodeList entryNodes = root.SelectNodes(GetSectionsPath(section) + "/entry[@name]");

                foreach (XmlNode node in entryNodes)
                    result.Add(node.Attributes["name"].Value, node.InnerText);
            }
            catch { }
            return result;
        }

        public bool IsExistsEntry(string section, string entry)
        {
            try
            {
                section = section.Trim(); entry = entry.Trim();
                XmlElement root = Document.DocumentElement;

                XmlNode entryNode = root.SelectSingleNode(GetSectionsPath(section) + "/" + GetEntryPath(entry));
                return entryNode != null;
            }
            catch { return false; }

        }

        public bool IsExistsSection(string section)
        {
            
            try
            {
                section = section.Trim();
                XmlElement root = Document.DocumentElement;
                // Get the entry nodes
                XmlNodeList entryNodes = root.SelectNodes(GetSectionsPath(section) + "/entry[@name]");
                return entryNodes != null;
            }
            catch { return false; }

        }

        public bool LoadXmlTxt(string XmlTxt)
        {
            try
            {
                Document.LoadXml(XmlTxt);
                return true;
            }
            catch { return false; }
        }

    }
}
