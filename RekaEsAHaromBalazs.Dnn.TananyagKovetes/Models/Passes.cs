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

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Models
{
    [TableName("Passes")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Pass", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Passes
    {
        ///<summary>
        /// The primary Id of the object
        ///</summary>
        public int ID { get; set; }

        ///<summary>
        /// The ID of the user, who made the order
        ///</summary>
        public string UserID { get; set; }
        /// <summary>
        /// Name of the course
        /// </summary>
        public string Name { get; set; }

        ///<summary>
        /// The date the order was made
        ///</summary>
        public DateTime TimeOfOrder { get; set; }

        ///<summary>
        /// The quantity of products in the order
        ///</summary>
        public int Quantity { get; set; }
        /// <summary>
        /// The amount of lessons left in the pass
        /// </summary>
        public int LessonsLeft { get; set; }
        /// <summary>
        /// The language of the ordered course
        /// </summary>
        public string Type { get; set; }
    }
}
