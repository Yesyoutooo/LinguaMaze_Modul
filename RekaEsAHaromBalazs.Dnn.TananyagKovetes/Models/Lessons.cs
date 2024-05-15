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
    [TableName("Lessons")]
    //setup the primary key for table
    [PrimaryKey("ID", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Lesson", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Lessons
    {
        ///<summary>
        /// The primary Id of the object
        ///</summary>
        public int ID { get; set; }

        /// <summary>
        /// Name of the lesson
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The language of the lesson
        /// </summary>
        public string Type { get; set; }

        ///<summary>
        /// The date the lesson will be held
        ///</summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// A bool that tell wethet the lesson will be held online or in person
        /// </summary>
        public bool Place { get; set; }

        /// <summary>
        /// A bool that tell wether the lesson was already booked
        /// </summary>
        public bool IsBooked { get; set; }
        
        
    }
}
