

namespace ProductionSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ProductionSystem.Web.Data;
    using ProductionSystem.Web.Data.Repositories.Interfaz;
    using ProductionSystem.Web.Helpers;
    using ProductionSystem.Web.Models;
    using System.Threading.Tasks;

    //[Authorize]
    public class PresentacionesController : Controller
    {
        private readonly DataContext _dataContext;

        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IValidatorHelper _validatorHelper;

        private readonly IPresentacionRepository _presentacionRepository;

        private readonly IEtiquetaRepository _etiquetaRepository;

        public PresentacionesController(
            DataContext dataContext,
            ICombosHelper comboHelper,
            IConverterHelper converterHelper,
            IValidatorHelper validatorHelper,
            IPresentacionRepository presentacionRepository,
            IEtiquetaRepository etiquetaRepository)
        {
            _dataContext = dataContext;

            _combosHelper = comboHelper;
            _converterHelper = converterHelper;
            _validatorHelper = validatorHelper;
            _presentacionRepository = presentacionRepository;
            _etiquetaRepository = etiquetaRepository;
        }

        public IActionResult Index()
        {
            return View(_presentacionRepository.GetPresentacionConEtiquetaEnvase());
        }


        public IActionResult Details(int? id)
        {

            if (id == null)
            {

                return NotFound();

            }


            var presentacion = _presentacionRepository.GetDetailsPresentacion(id);


            if (presentacion == null)
            {
                return NotFound();
            }

            return View(presentacion);



        }


        public IActionResult Create()
        {

            //Aqui necesitamos enviar los combo box respectiivos

            var model = new AddPresentacionViewModel
            {

                Envases = _combosHelper.GetComboEnvases(),
                Etiquetas = _combosHelper.GetComboEtiqueta()


            };

            return View(model);
        }

        //TODO : Tenemos que validad que las etiquetas no lleguen al combo si es que estan usadas
        [HttpPost]
        public async Task<IActionResult> Create(AddPresentacionViewModel model)
        {

            //Aqui igual tenemos que hacer lo corresopndiente
            if (_validatorHelper.IsEtiquetaUsed(model.EtiquetaId))
            {
                return RedirectToAction("Error");
            }

            if (ModelState.IsValid)
            {

                var etiqueta = _etiquetaRepository.GetEtiqueta(model.EtiquetaId);
                var presentacion = await _converterHelper.ToPresentacionAsync(model);



                await _presentacionRepository.CreateAsync(presentacion);



                //Solo depsues que se haya guardado los datos, tenemos que insertar la etiqueta

                etiqueta.IsUsed = true;


                await _etiquetaRepository.UpdateAsync(etiqueta);


                return RedirectToAction("Index");


            }

            return View(model);



        }


        public IActionResult Error()
        {


            return View();
        }



        //Cuando eliminamos una presentacion debemos cambiar el estado de esta etiqueta a disponible.
        //La pantalla de edit tambien
        // GET: Owners/Delete/5
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }


            var presentacion = _presentacionRepository.GetDetailsPresentacion(id);

            if (presentacion == null)
            {
                return NotFound();
            }





            return View(presentacion);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            var presentacion = _presentacionRepository.GetPresentacionAsync(id);



            var etiqueta = _etiquetaRepository.GetEtiqueta(presentacion.Etiqueta.Id);

            await _presentacionRepository.DeleteAsync(presentacion);

            etiqueta.IsUsed = false;

            await _etiquetaRepository.UpdateAsync(etiqueta);


            return RedirectToAction(nameof(Index));



        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = _presentacionRepository.GetDetailsPresentacion(id);

            if (presentacion == null)
            {
                return NotFound();
            }


            var model = _converterHelper.ToPresentacionViewModelAsync(presentacion);




            return View(model);
        }

        //Hay un problema, tenemos que validar que el estado de una etiqueta no sea true, asi no cambiamos
        //No podemos validar que el atributo tenga solamente un metodo, debemos crear una clase o algo que nos ayude a verificar,
        //Pero tiene que aparecer en el model.
        [HttpPost]
        public async Task<IActionResult> Edit(AddPresentacionViewModel model)
        {
            if (_validatorHelper.IsEtiquetaUsed(model.EtiquetaId))
            {
                //Aqui tiene que venir una ventana de error.
                return RedirectToAction("Error");
            }



            if (ModelState.IsValid)
            {
                //El id de la presentacion tiene que ser igual al id de la etiqueta por la relacion 1-1
                var presentacion = await _converterHelper.ToPresentacionAsync(model);

                var etiqueta = _etiquetaRepository.GetEtiqueta(model.FormerEtiquetaId);




                await _presentacionRepository.UpdateAsync(presentacion);

                etiqueta.IsUsed = false;

                await _etiquetaRepository.UpdateAsync(etiqueta);

                etiqueta = _etiquetaRepository.GetEtiqueta(model.EtiquetaId);
                //Esto en teoria no deberia estar aca, se puede hacer una abstraccion mas, pero como no es un cambio de
                //La base de datos, sino del objeto en si creo que estaria permitido.
                etiqueta.IsUsed = true;


                await _etiquetaRepository.UpdateAsync(etiqueta);


                //Dtalles del propietario
                return RedirectToAction("Index");

            }

            return View(model);
        }









    }
}