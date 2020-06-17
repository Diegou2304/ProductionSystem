using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using ProductionSystem.Web.Helpers;
using ProductionSystem.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Controllers
{
    public class PagosController : Controller
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IValidatorHelper _validatorHelper;
        private readonly IPagoRepository _IpagoRepository;

        public PagosController(DataContext context,
            IConverterHelper converterHelper,
            ICombosHelper combosHelper,
            IValidatorHelper validatorHelper,
            IPagoRepository pagoRepository)
        {
            _context = context;
            _converterHelper = converterHelper;
            _combosHelper = combosHelper;
            _validatorHelper = validatorHelper;
            _IpagoRepository = pagoRepository;
        }

        // GET: Pagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pagos.Include(e => e.Empresa).ToListAsync());
        }

        // GET: Pagos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
          

       
            return View(_IpagoRepository.GetPagosCompletos(id));
        }

        // GET: Pagos/Create
        public IActionResult Create()
        {


            var model = new PagoViewModel
            {
                Empresas = _combosHelper.GetComboEmpresas(),
                ProductosFinales = _combosHelper.GetComboProductosReales(),
            };
            return View(model);
        }

        // POST: Pagos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PagoViewModel model)
        {
            
            
            
            
            if (ModelState.IsValid)
            {

                if(!_validatorHelper.IsEnoughProduct(model.IdProductoFinal,model.UnidadesPagadas))
                {
                    return RedirectToAction("Error");
                }

              
                var pago= await _converterHelper.ToPagoAsync(model);



                _context.Pagos.Add(pago);

                _context.SaveChanges();

                var producto = await _context.ProductoReal.FindAsync(model.IdProductoFinal);
                producto.stock = producto.stock - model.UnidadesPagadas;

                _context.ProductoReal.Update(producto);

                _context.SaveChanges();


                //Aqui tenemos que introducir producto pago con los datos del model.

                var productopago = await  _converterHelper.ToProductoPagoAsync(model);

                _context.ProductoPagos.Add(productopago);

                _context.SaveChanges();



                return RedirectToAction("Index");


            }
            else
            {
                model.Empresas = _combosHelper.GetComboEmpresas();
               

            }

            return View(model);




        }

        public IActionResult Error()
        {


            return View();
        }



        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
