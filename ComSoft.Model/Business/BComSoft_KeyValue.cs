/**************************************************************
 * CREADO POR : GRUPO COMSOFT
 *              Cristian Hernandez Villo
 * FECHA CREA : 06/09/2018
**************************************************************/

namespace ComSoft.Model.Business
{
    using ComSoft.Model.Entity;
    using CristianHernandez;
    using System;
    using System.IO;
    using System.Xml;

    public class BComSoft_KeyValue
    {
        public CHObservableCollection<EComSoft_KeyValue> GET_DocumentoSunat()
        {
            try
            {
                var instCollection = new CHObservableCollection<EComSoft_KeyValue>();
                var instXmlDocument = new XmlDocument();
                instXmlDocument.Load(Path.Combine(Directory.GetCurrentDirectory(), @"File\XML\ComSoftDataSunat_PaymentVoucher.xml"));
                var vrXmlNodeList = instXmlDocument.GetElementsByTagName("PaymentVoucher");
                var XmlNodeList = ((XmlElement)vrXmlNodeList[0]).GetElementsByTagName("Voucher");
                foreach (XmlElement nodo in XmlNodeList)
                {
                    instCollection.Add(new EComSoft_KeyValue()
                    {
                        Key = nodo.GetElementsByTagName("Code")[0].InnerText,
                        Value = nodo.GetElementsByTagName("Decription")[0].InnerText,
                    });
                }
                return instCollection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
