using Newtonsoft.Json;
using RecognizeProfiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RecognizeProfiles.Entities
{
    public class TemplateRepository
    {
        public string _nameFile = @"Templates\\templates.xml";
        public List<TemplateModel> GetAll()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(_nameFile);
                JsonSerializer serializer = new JsonSerializer();
                var matchMatchings = from c in xmlDoc.Elements("DocumentElement").Descendants("Entity")
                                     select new TemplateModel
                                     {
                                         Id = (string)c.Element("Id") != null ? (string)c.Element("Id").Value : "",
                                         Name = (string)c.Element("Name") != null ? (string)c.Element("Name").Value : "",
                                         Positions = (string)c.Element("Positions") != null ? JsonConvert.DeserializeObject<List<PositionModel>>((string)c.Element("Positions")) : null
                                     };
                return matchMatchings.ToList();
            }
            catch
            {
                return null;
            }
        }
        //Add
        public void Add(TemplateModel TemplateModel) //Add
        {
            try
            {
                var doc = XDocument.Load(_nameFile);
                
                var batchmatching =
                        new XElement("Entity",
                        new XElement("Id",Guid.NewGuid()),
                        new XElement("Name", TemplateModel.Name),
                        new XElement("Positions",JsonConvert.SerializeObject(TemplateModel.Positions)));
                doc.Element("DocumentElement").Add(batchmatching);
                doc.Save(_nameFile);

            }
            catch (Exception ex)
            {
                string abc = ex.ToString();

            }//Bỏ qua các giá trị lỗi như NULL...
        }
        ////Del
        public bool Delete(string id)
        {
            try
            {
                var doc = XDocument.Load(_nameFile);
                doc.Elements("DocumentElement").Elements("Entity").Where(x => x.Element("Id").Value == id).Remove();
                doc.Save(_nameFile);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        ////Edit
        public bool Update(string id, TemplateModel TypeNumberModel)
        {
            try
            {
                var doc = XDocument.Load(_nameFile);
                var siNode = doc.Elements("DocumentElement").Elements("Entity").Where(x => x.Element("Id").Value == id.Trim()).FirstOrDefault();
                siNode.Elements("Name").SingleOrDefault().Value = TypeNumberModel.Name.Trim();
                if (TypeNumberModel.Positions != null)
                {
                    siNode.Elements("Positions").SingleOrDefault().Value = JsonConvert.SerializeObject(TypeNumberModel.Positions);
                }
                doc.Save(_nameFile);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        ////Find
        public TemplateModel Find(string Id)
        {
            var doc = XDocument.Load(_nameFile);
            try
            {
                var note = (from c in doc.Descendants("Entity")
                            where c.Element("Id").Value == Id
                            select new TemplateModel
                            {
                                Id = (string)c.Element("Id") != null ? (string)c.Element("Id").Value : "",
                                Name = (string)c.Element("Name") != null ? (string)c.Element("Name").Value : "",
                                Positions = (string)c.Element("Positions") != null ? JsonConvert.DeserializeObject<List<PositionModel>>((string)c.Element("Positions")) : null
                            }
                            ).SingleOrDefault();
                return note;
            }
            catch (Exception)
            {
                return null;
            }
        }
        ////Find by Value
        public TemplateModel FindByName(string name)
        {
            List<TemplateModel> lstTemp = FindAll(name);
            if (lstTemp != null) return lstTemp.FirstOrDefault();
            else return null;
        }

        ////Find All
        public List<TemplateModel> FindAll(string name)
        {
            var doc = XDocument.Load(_nameFile);
            try
            {
                var note = (from c in doc.Descendants("Entity")
                            where c.Element("Name").Value.Contains(name)
                            select new TemplateModel
                            {
                                Id = (string)c.Element("Id") != null ? (string)c.Element("Id").Value : "",
                                Name = (string)c.Element("Name") != null ? (string)c.Element("Name").Value : "",
                                Positions = (string)c.Element("Positions") != null ? JsonConvert.DeserializeObject<List<PositionModel>>((string)c.Element("Positions")) : null
                            }
                            ).ToList();
                return note;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
