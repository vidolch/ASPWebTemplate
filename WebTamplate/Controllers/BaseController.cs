namespace WebTamplate.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper;
    using Mapping;
    using DataAccess.Repositories;
    using Services;
    using ViewModels;
    using DataAccess.Models;

    public class BaseController<T, TViewModel, TListViewModel, TEditViewModel> : Controller
        where T : BaseEntity
        where TListViewModel : BaseListViewModel<TViewModel>, new()
    {
        private BaseRepository<T> db = new BaseRepository<T>();

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        // GET: <BaseEntity>
        public virtual ActionResult Index()
        {
            TListViewModel viewModel = new TListViewModel();

            viewModel = viewModel.PopulatePagingData<T, TListViewModel, TViewModel>(this.db, this.Request.QueryString, this.GetControllerName());

            return this.View(viewModel);
        }

        // GET: <BaseEntity>/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = this.db.Find(x => x.Id == (int)id).AsQueryable().To<TViewModel>().First();

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(viewModel);
        }

        // GET: <BaseEntity>/Create
        public virtual ActionResult Create()
        {
            return this.View();
        }

        // GET: <BaseEntity>/Edit/5
        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TEditViewModel viewModel = this.db.Find(t => t.Id == id).AsQueryable()
                .To<TEditViewModel>().FirstOrDefault();

            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(viewModel);
        }

        // POST: <BaseEntity>/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(TEditViewModel entityViewModel)
        {
            T entity = this.Mapper.Map<T>(entityViewModel);

            if (this.ModelState.IsValid)
            {
                this.db.AddOrUpdate(entity);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            if (entity.Id == 0)
            {
                return this.View("Create", entityViewModel);
            }

            return this.View(entityViewModel);
        }

        // GET: <BaseEntity>/Delete/5
        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TViewModel viewModel = this.Mapper.Map<TViewModel>(this.db.Get((int)id));
            if (viewModel == null)
            {
                return this.HttpNotFound();
            }

            return this.View(viewModel);
        }

        // POST: <BaseEntity>/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            T entity = this.db.Get(id);
            this.db.Remove(entity);
            this.db.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        protected virtual string GetControllerName()
        {
            return this.GetType().Name.ToString().Split(new string[] { "Controller" }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}