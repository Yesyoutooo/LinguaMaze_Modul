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

using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Components;
using TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Models;

namespace TananyagKovetesRekaEsAHaromBalazs.Dnn.TananyagKovetes.Controllers
{
    [DnnHandleError]
    public class ItemController : DnnController
    {
        public ActionResult Delete(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var userlist = UserController.GetUsers(PortalSettings.PortalId);
            var users = from user in userlist.Cast<UserInfo>().ToList()
                        select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

            ViewBag.Users = users;

            var item = (itemId == -1)
                 ? new Item { ModuleId = ModuleContext.ModuleId }
                 : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item);
        }

        [HttpPost]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {
            if (item.ItemId == -1)
            {
                item.CreatedByUserId = User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastModifiedByUserId = User.UserID;
                item.LastModifiedOnDate = DateTime.UtcNow;

                ItemManager.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
                existingItem.LastModifiedByUserId = User.UserID;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
                existingItem.AssignedUserId = item.AssignedUserId;

                ItemManager.Instance.UpdateItem(existingItem);
            }

            return RedirectToDefaultRoute();
        }

        public ActionResult CreateBooking(int lessonID, int activePassID)
        {
            Bookings newBooking = new Bookings();

            newBooking.PassID = activePassID;
            newBooking.LessonID = lessonID;
            newBooking.ModifiedAt = DateTime.UtcNow;
            newBooking.IsCancelled = false;

            BookingManager.Instance.CreateBooking(newBooking);

            var chosenLesson = LessonManager.Instance.GetLessonByID(lessonID);

            chosenLesson.FirstOrDefault().IsBooked = true;
            LessonManager.Instance.UpdateLesson(chosenLesson.FirstOrDefault());

            var chosenPass = PassesManager.Instance.GetPassByID(activePassID);
            chosenPass.LessonsLeft -= 1;
            PassesManager.Instance.UpdatePass(chosenPass);
            
            return View("Subscribed");
          
        }

        public ActionResult CancelBooking(int lessonID, int activePassID)
        {
            var chosenBooking = BookingManager.Instance.GetBookingByLessonID(lessonID);
            chosenBooking.FirstOrDefault().IsCancelled = true;
            BookingManager.Instance.UpdateBooking(chosenBooking.FirstOrDefault());

            var chosenLesson = LessonManager.Instance.GetLessonByID(lessonID);
            chosenLesson.FirstOrDefault().IsBooked = false;
            LessonManager.Instance.UpdateLesson(chosenLesson.FirstOrDefault());

            var chosenPass = PassesManager.Instance.GetPassByID(activePassID);
            chosenPass.LessonsLeft += 1;
            PassesManager.Instance.UpdatePass(chosenPass);

            return View("Cancelled");

        }

        [HttpGet]
        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var current_user_ID = base.User.UserID;

            var passes = PassesManager.Instance.GetPassesByUserID(current_user_ID);

            if (passes.Count() <= 0)
            {
                return View("Még nem vásároltál privát órát!");
            }
            else
            {
                List<Passes> pass_List = new List<Passes>();
                foreach (var item in passes)
                {
                    pass_List.Add(item);
                }
                return View(pass_List);
            }
        }

        
        public ActionResult GetAvailableLessons(string type,int clickedPassID)
        {
            if (clickedPassID != -1)
            {
                TempData["clickedPassID"] = clickedPassID;
            }


            var lessons = LessonManager.Instance.GetLessonsByType(type);

            if (lessons.Count() <= 0)
            {
                return View("Egylőre nincsenek privát órák ehhez a nyelvhez.");
            }
            else
            {
                List<Lessons> lessons_list = new List<Lessons>();
                foreach (var item in lessons)
                {
                    lessons_list.Add(item);
                }
                var ordered_lessons_list = lessons_list.OrderBy(i => i.DateTime).ToList();
                return View("GetAvailableLessons", ordered_lessons_list);
            }
        }

        public ActionResult GetSubscriptions(int chosenPass)
        {
            var clickedPassBookings = BookingManager.Instance.GetBookedLessonsByPassID(chosenPass);
            List<Lessons> lessonsToList = new List<Lessons>();
            if (chosenPass != -1)
            {
                TempData["clickedPassID"] = chosenPass;
            }

            foreach (var item in clickedPassBookings)
            {
                if (item.IsCancelled == false)
                {
                    lessonsToList.Add(LessonManager.Instance.GetLesson(item.LessonID));
                    ViewBag.e = item.IsCancelled;
                }
            }
            var ordered_lessons_list = lessonsToList.OrderBy(i => i.DateTime).ToList();
            return View("GetSubscriptions", ordered_lessons_list);

        }

        [HttpGet]
        public ActionResult ShowLessonDetails(int lessonID)
        {
            var selectedLesson = LessonManager.Instance.GetLessonByID(lessonID);

            List<Lessons> lessons_list = new List<Lessons>();
            foreach (var item in selectedLesson)
            {
                lessons_list.Add(item);
            }
            return View("ShowLessonDetails", lessons_list);
        }

        [HttpGet]
        public ActionResult ShowSubscriptionDetails(int lessonID)
        {
            var selectedLesson = LessonManager.Instance.GetLessonByID(lessonID);

            List<Lessons> lessons_list = new List<Lessons>();
            foreach (var item in selectedLesson)
            {
                lessons_list.Add(item);
            }
            return View("ShowSubscriptionDetails", lessons_list);
        }

    }
}
