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

using DotNetNuke.Data;
using DotNetNuke.Framework;
using System.Collections.Generic;
using TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Models;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Components
{
    internal interface IBookingManager
    {
        IEnumerable<Bookings> GetItems(int moduleId);
        Bookings GetBooking(string orderId);
        IEnumerable<Bookings> GetBookedLessons(int passId);
        void CreateBooking(Bookings t);
    }

    internal class BookingManager : ServiceLocator<IBookingManager, BookingManager>, IBookingManager
    {
        public IEnumerable<Bookings> GetItems(int moduleId)
        {
            IEnumerable<Bookings> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Bookings>();
                t = rep.Get();
            }
            return t;
        }

        public Bookings GetBooking(string bookingId)
        {
            Bookings t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Bookings>();
                t = rep.GetById(bookingId);
            }
            return t;
        }

        public IEnumerable<Bookings> GetBookedLessons(int passId)
        {
            IEnumerable<Bookings> bookedLesson;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Bookings>();
                bookedLesson = rep.Find("WHERE Type = @0", passId);
            }
            return bookedLesson;
        }


        public void CreateBooking(Bookings t)
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Bookings>();
                try
                {
                    rep.Insert(t);
                }
                catch (System.NullReferenceException)
                {

                }
            }
        }

        protected override System.Func<IBookingManager> GetFactory()
        {
            return () => new BookingManager();
        }

    }
}
