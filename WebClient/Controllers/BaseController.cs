namespace WebClient.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper;
    using Mapping;
    using ViewModels;
    using DataAccess.Models;
    using Services.EntityServices;

    public class BaseController<T, TViewModel, TListViewModel, TEditViewModel, TService, TFilterViewModel> : Controller
        where T : BaseEntity
        where TViewModel : BaseEntityViewModel
        where TFilterViewModel : BaseFilterViewModel<T>, new()
        where TListViewModel : BaseListViewModel<T, TFilterViewModel>, new()
        where TService : BaseService<T>, new()
    {
        private TService service;

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        public BaseController()
        {
            this.service = new TService();
        }

        // GET: <BaseEntity>
        public virtual ActionResult Index()
        {
            TListViewModel model = new TListViewModel();
            model.Pager = new BasePaginationViewModel();
            model.Filter = new TFilterViewModel();
            TryUpdateModel(model);

            model = model.PopulatePagingData<T, TListViewModel, TViewModel, TFilterViewModel>(this.service, this.Request.QueryString, this.GetControllerName());

            return this.View(model);
        }

        // GET: <BaseEntity>/Details/5
        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var viewModel = this.service.GetAll(x => x.Id == (int)id).AsQueryable().To<TViewModel>().First();

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

            TEditViewModel viewModel = this.service.GetAll(t => t.Id == id).AsQueryable()
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
                this.service.AddOrUpdate(entity);
                this.service.SaveChanges();

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

            TViewModel viewModel = this.Mapper.Map<TViewModel>(this.service.Get((int)id));
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
            T entity = this.service.Get(id);
            this.service.Remove(entity);
            this.service.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.service.Dispose();
            }

            base.Dispose(disposing);
        }

        protected virtual string GetControllerName()
        {
            return this.GetType().Name.ToString().Split(new string[] { "Controller" }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}