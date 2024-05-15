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
    [TableName("Bookings")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Booking", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Bookings
    {
        ///<summary>
        /// The primary Id of the object
        ///</summary>
        public int ID { get; set; }
        ///<summary>
        /// ID of the user's pass
        ///</summary>
        public int PassID { get; set; }
        ///<summary>
        /// ID of the booked lesson
        ///</summary>
        public int LessonID { get; set; }

        ///<summary>
        /// Date of the last modification of the booking
        ///</summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        /// Tell wether the booking is cancelled
        /// </summary>
        public bool IsCancelled { get; set; }
    }
}
