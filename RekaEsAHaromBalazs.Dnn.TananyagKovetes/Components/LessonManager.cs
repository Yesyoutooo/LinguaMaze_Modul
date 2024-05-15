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
    internal interface ILessonManager
    {
        IEnumerable<Lessons> GetItems(int moduleId);
        Lessons GetLesson(string orderId);
        IEnumerable<Lessons> GetLessonsByType(string type);

        IEnumerable<Lessons> GetLessonByID(int lessonID);
    }

    internal class LessonManager : ServiceLocator<ILessonManager, LessonManager>, ILessonManager
    {
        public IEnumerable<Lessons> GetItems(int moduleId)
        {
            IEnumerable<Lessons> t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Lessons>();
                t = rep.Get();
            }
            return t;
        }

        public Lessons GetLesson(string lessonId)
        {
            Lessons t;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Lessons>();
                t = rep.GetById(lessonId);
            }
            return t;
        }

        public IEnumerable<Lessons> GetLessonsByType(string type)
        {
            IEnumerable<Lessons> lessonOfType;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Lessons>();
                lessonOfType = rep.Find("WHERE Type = @0", type);
            }
            return lessonOfType;
        }

        public IEnumerable<Lessons> GetLessonByID(int lessonID)
        {
            IEnumerable<Lessons> selectedLesson;
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<Lessons>();
                selectedLesson = rep.Find("WHERE ID = @0", lessonID);
            }
                return selectedLesson;
        }

        protected override System.Func<ILessonManager> GetFactory()
        {
            return () => new LessonManager();
        }
    }
}
