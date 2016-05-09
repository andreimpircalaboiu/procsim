using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AndreisMathsExpressionEvaluator
{
    public class HistorySaver
    {
        private const string _fileName = "\\history.txt";
        private DateTime _dateAndTime;
        private DateTime _dateExists;

#region XMLSave
        /*
        public void SaveXML(object rootObject)
        {
            if (rootObject == null) throw new ArgumentNullException("nu avem ce salva");

            XmlWriter writer = null;
            try
            {
                writer = XmlWriter.Create(Application.StartupPath + _fileName, new XmlWriterSettings
                {
                    CloseOutput = true,
                    Indent = true,
                    IndentChars = "    "
                });

                var dataContractSerializer = new DataContractSerializer(rootObject.GetType());

                dataContractSerializer.WriteObject(writer, rootObject);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        */
#endregion

        public void Save(string expressionToLoad, string resultToLoad)
        {
            _dateAndTime = DateTime.Now;
            var fileLocation = Application.StartupPath + _fileName ;
            var bla = _dateAndTime.ToShortDateString();
            var dateExistsBool = File.ReadAllText(fileLocation).Contains(bla);
            if(dateExistsBool)
            using (var file = new StreamWriter(fileLocation,true))
            {
              
                file.WriteLine(_dateAndTime.ToLongTimeString());
                file.WriteLine(_expressionToLoad + " = " + _resultToLoad);
                file.WriteLine();
            }
            else
            {
                using (var file = new StreamWriter(fileLocation, true))
                {
                  
                    file.WriteLine(_dateAndTime);
                    file.WriteLine(_expressionToLoad + " = " + _resultToLoad);
                    file.WriteLine();
                }
            }
        }
    }
}
