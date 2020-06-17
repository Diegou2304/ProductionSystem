using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductionSystem.Web.Data;
using ProductionSystem.Web.Data.Entities;
using ProductionSystem.Web.Data.Repositories.Interfaz;
using ProductionSystem.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _dataContext;
        private readonly ICombosHelper _combosHelper;
        private readonly IFaseRepository faseRepository;
        private readonly IEmpleadoProduccionRepository empleadoProduccionRepository;
        private readonly IUserHelper userHelper;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IInsumoRepository insumoRepository;
        private readonly IProduccionRepository produccionRepository;

        public ConverterHelper(
            DataContext dataContext,
            ICombosHelper combosHelper,
            IFaseRepository faseRepository,
            IEmpleadoProduccionRepository empleadoProduccionRepository,
            IUserHelper userHelper,
            IPedidoRepository pedidoRepository,
            IInsumoRepository insumoRepository,
            IProduccionRepository produccionRepository)
        {

            _dataContext = dataContext;
            _combosHelper = combosHelper;
            this.faseRepository = faseRepository;
            this.empleadoProduccionRepository = empleadoProduccionRepository;
            this.userHelper = userHelper;
            this.pedidoRepository = pedidoRepository;
            this.insumoRepository = insumoRepository;
            this.produccionRepository = produccionRepository;
        }

        public InsumoUsado ToInsumoUsado(InsumoUsadoViewModel model)
        {
            var produccion = produccionRepository.GetProduccionById(model.ProduccionId);
            var insumo = insumoRepository.GetInsumoById(model.InsumoId);

            return new InsumoUsado
            {
                CantidadUsada = model.CantidadUsada,
                Produccion = produccion,
                Insumo = insumo,
            };


        }


        public async Task<Produccion> ToProduccionAsync(ProduccionViewModel model)
        {

            return new Produccion
            {
                //por algun motivo esto no va aqui
                //Id = model.Id,

                FechaProduccion = model.FechaProduccion,
                //
                EmpleadoProducción = await empleadoProduccionRepository.GetEmpleadoPorCI(model.UserCi),
                Fase = await faseRepository.GetFasePorNumeroAsync(model.FaseId),
                Pedido = pedidoRepository.GetPedidos(model.PedidoId),
                               
            };

        }


        //Pedido
        public async Task<Pedido> ToPedidoAsync(PedidoViewModel model)
        {
            return new Pedido
            {
               
                Fecha = model.Fecha,
                estado = "Pendiente",
                //Cambiar esto es solo de prueba
                NumeroFase = 1,
                ProductoReal = await _dataContext.ProductoReal.FindAsync(model.ProductoRealId),
                Id = model.Id,
                Cantidad = model.Cantidad

            };
        }

        public PedidoViewModel ToPedidoViewModel(Pedido model)
        {
            //Le llega con todos los datos

            return new PedidoViewModel
            {
                Id = model.Id,
                Cantidad = model.Cantidad,
                Fecha = model.Fecha,
                estado = model.estado,
                NumeroFase = model.NumeroFase,
                ProductoReal = model.ProductoReal,
                ProductosReales = _combosHelper.GetComboProductosReales(),
                ProductoRealId = model.ProductoReal.Id,

            };

        }

        //Presentacion
        public async Task<Presentacion> ToPresentacionAsync(AddPresentacionViewModel model)
        {

            return new Presentacion
            {


                Nombre = model.Nombre,
                Etiqueta = await _dataContext.Etiquetas.FindAsync(model.EtiquetaId),
                Envase = await _dataContext.Envases.FindAsync(model.EnvaseId),
                Id = model.Id



            };

        }

        public AddPresentacionViewModel ToPresentacionViewModelAsync(Presentacion model)
        {
            //Le llega con todos los datos

            return new AddPresentacionViewModel
            {
                Id = model.Id,
                Nombre = model.Nombre,
                EnvaseId = model.Envase.Id,
                EtiquetaId = model.Etiqueta.Id,
                Etiqueta = model.Etiqueta,
                Envase = model.Envase,
                Envases = _combosHelper.GetComboEnvases(),

                Etiquetas = _combosHelper.GetComboEtiqueta(),

                FormerEtiquetaId = model.Etiqueta.Id



            };

        }
        
        //Producto
        public async Task<Producto> ToProductoAsync(ProductoViewModel model)
        {
            return new Producto
            {

                Nombre = model.Nombre,
                Categoria = await _dataContext.Categorias.FindAsync(model.CategoriaId),

                TipoProducto = await _dataContext.TipoProductos.FindAsync(model.TipoProductoId),
                Sabor = await _dataContext.Sabores.FindAsync(model.SaborId),
                Presentacion = await _dataContext.Presentaciones.FindAsync(model.PresentacionId),

                Id = model.Id,

            };


        }

        public async Task<ProductoReal> ToProductoRealAsync(ProductoRealViewModel model)
        {
            return new ProductoReal
            {

                Nombre = model.Nombre,
                stock = model.stock,
                Producto = await _dataContext.Productos.FindAsync(model.ProductoId),

                Id = model.Id,

            };
        }
        
        public ProductoViewModel ToProductoViewModel(Producto model)
        {
            return new ProductoViewModel
            {
                Id = model.Id,

                Nombre = model.Nombre,

                CategoriaId = model.Categoria.Id,

                TipoProductoId = model.TipoProducto.Id,

                SaborId = model.Sabor.Id,

                PresentacionId = model.Presentacion.Id,

                Categoria = model.Categoria,

                TipoProducto = model.TipoProducto,

                Sabor = model.Sabor,

                Presentacion = model.Presentacion,



                Categorias = _combosHelper.GetComboCategorias(),

                TiposProductos = _combosHelper.GetComboTipoProducto(),

                Sabores = _combosHelper.GetComboSabores(),

                Presentaciones = _combosHelper.GetComboPresentaciones(),




            };

        }

        //Receta
        public async Task<Receta> ToRecetaAsync(RecetaViewModel model)
        {
            return new Receta
            {

                Id= model.Id,

                Insumo = await _dataContext.Insumos.FindAsync(model.InsumoId),

                ProductoReal = await _dataContext.ProductoReal.FindAsync(model.ProductoRealId),

                Porcentaje = model.Porcentaje,


            };
        }

        public RecetaViewModel ToRecetaViewModel(Receta model)
        {
            return new RecetaViewModel
            {
                Id = model.Id,

                Porcentaje = model.Porcentaje,

                InsumoId = model.Insumo.Id,

                ProductoRealId = model.ProductoReal.Id,

                Insumo = model.Insumo,

                ProductoReal = model.ProductoReal,
                
                Insumos = _combosHelper.GetComboInsumo(),

                ProductosReales = _combosHelper.GetComboProductosReales(),
                      
            };
        }

        //Empleado Produccion
        public async Task<EmpleadoProduccion> ToEmpleadoProduccionAsync(EmpleadoProduccionViewModel model)
        {
            return new EmpleadoProduccion
            {

                Id = model.Id,

                Nombre = model.Nombre,

                ApellidoPaterno = model.ApellidoPaterno,

                ApellidoMaterno = model.ApellidoMaterno,

                Direccion = model.Direccion,

                Cargo = model.Cargo,

                Ci = model.Ci,

                Telefono = model.Telefono,

                //aqui se busca en la tabla fases la fase seleccionada 
                Fase = await _dataContext.Fases.FindAsync(model.FaseId),
                
                

            };
        }

        public EmpleadoProduccionViewModel ToEmpleadoProduccionViewModel(EmpleadoProduccion model)
        {
            return new EmpleadoProduccionViewModel
            {
                Id = model.Id,

                Nombre = model.Nombre,

                ApellidoPaterno = model.ApellidoPaterno,

                ApellidoMaterno = model.ApellidoMaterno,

                Direccion = model.Direccion,

                Cargo = model.Cargo,

                Ci = model.Ci,

                Telefono = model.Telefono,

                Fases = _combosHelper.GetComboFases(),

            };
        }

        //User
        public async Task<User> ToUserAsync(RegisterUserViewModel model)
        {
            return new User
            {

                Nombre = model.Nombre,

                ApellidoPaterno = model.ApellidoPaterno,

                ApellidoMaterno = model.ApellidoMaterno,

                Ci = model.Ci,

                UserName = model.UserName,

                Email = model.UserName,

                Disponible = true,

                Cargo = await faseRepository.GetNombreFaseAsync(model.CargoId),

                CargoNumero = await faseRepository.GetNumeroFaseAsync(model.CargoId),
                
            };
        }

        public async Task<Sucursal> ToSucursal(SucursalViewModel model)
        {
            return new Sucursal
            {

               

                Nombre = model.Nombre,

                
                Direccion = model.Direccion,

                Encargado = model.Encargado,

                Empresa = await  _dataContext.Empresas.FindAsync(model.EmpresaId),


            };
        }

        public async Task<Pago> ToPagoAsync(PagoViewModel model)
        {
            return new Pago
            {



                Nombre = model.Nombre,


                MontoTotal = model.MontoTotal,

                Fecha = model.Fecha,

                Empresa = await  _dataContext.Empresas.FindAsync(model.EmpresaId),


            };
        }

        public async Task<ProductoPago> ToProductoPagoAsync(PagoViewModel model)
        {
            return new ProductoPago
            {



                Monto = model.MontoPago,

                UnidadesPagadas = model.UnidadesPagadas,
                ProductoReal = await _dataContext.ProductoReal.FindAsync(model.EmpresaId),

                Pago =await  _dataContext.Pagos.LastAsync(),
               
            };

        }
    }
}
