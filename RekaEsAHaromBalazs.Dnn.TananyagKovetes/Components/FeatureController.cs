/*
' Copyright (c) 2024 RekaEsAHaromBalazs
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using System.Collections.Generic;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Components
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for RekaEsAHaromBalazs.Dnn.TananyagKovetes
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo> colRekaEsAHaromBalazs.Dnn.TananyagKovetess = GetRekaEsAHaromBalazs.Dnn.TananyagKovetess(ModuleID);
        //if (colRekaEsAHaromBalazs.Dnn.TananyagKovetess.Count != 0)
        //{
        //    strXML += "<RekaEsAHaromBalazs.Dnn.TananyagKovetess>";

        //    foreach (RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo objRekaEsAHaromBalazs.Dnn.TananyagKovetes in colRekaEsAHaromBalazs.Dnn.TananyagKovetess)
        //    {
        //        strXML += "<RekaEsAHaromBalazs.Dnn.TananyagKovetes>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objRekaEsAHaromBalazs.Dnn.TananyagKovetes.Content) + "</content>";
        //        strXML += "</RekaEsAHaromBalazs.Dnn.TananyagKovetes>";
        //    }
        //    strXML += "</RekaEsAHaromBalazs.Dnn.TananyagKovetess>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlRekaEsAHaromBalazs.Dnn.TananyagKovetess = DotNetNuke.Common.Globals.GetContent(Content, "RekaEsAHaromBalazs.Dnn.TananyagKovetess");
        //foreach (XmlNode xmlRekaEsAHaromBalazs.Dnn.TananyagKovetes in xmlRekaEsAHaromBalazs.Dnn.TananyagKovetess.SelectNodes("RekaEsAHaromBalazs.Dnn.TananyagKovetes"))
        //{
        //    RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo objRekaEsAHaromBalazs.Dnn.TananyagKovetes = new RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo();
        //    objRekaEsAHaromBalazs.Dnn.TananyagKovetes.ModuleId = ModuleID;
        //    objRekaEsAHaromBalazs.Dnn.TananyagKovetes.Content = xmlRekaEsAHaromBalazs.Dnn.TananyagKovetes.SelectSingleNode("content").InnerText;
        //    objRekaEsAHaromBalazs.Dnn.TananyagKovetes.CreatedByUser = UserID;
        //    AddRekaEsAHaromBalazs.Dnn.TananyagKovetes(objRekaEsAHaromBalazs.Dnn.TananyagKovetes);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo> colRekaEsAHaromBalazs.Dnn.TananyagKovetess = GetRekaEsAHaromBalazs.Dnn.TananyagKovetess(ModInfo.ModuleID);

        //foreach (RekaEsAHaromBalazs.Dnn.TananyagKovetesInfo objRekaEsAHaromBalazs.Dnn.TananyagKovetes in colRekaEsAHaromBalazs.Dnn.TananyagKovetess)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objRekaEsAHaromBalazs.Dnn.TananyagKovetes.Content, objRekaEsAHaromBalazs.Dnn.TananyagKovetes.CreatedByUser, objRekaEsAHaromBalazs.Dnn.TananyagKovetes.CreatedDate, ModInfo.ModuleID, objRekaEsAHaromBalazs.Dnn.TananyagKovetes.ItemId.ToString(), objRekaEsAHaromBalazs.Dnn.TananyagKovetes.Content, "ItemId=" + objRekaEsAHaromBalazs.Dnn.TananyagKovetes.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
