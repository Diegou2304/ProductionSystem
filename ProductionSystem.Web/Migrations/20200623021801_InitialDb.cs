using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductionSystem.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Ci = table.Column<int>(nullable: false),
                    Cargo = table.Column<string>(nullable: false),
                    CargoNumero = table.Column<int>(nullable: false),
                    Disponible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Envases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacidad = table.Column<int>(nullable: false),
                    Isplastic = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiquetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Altura = table.Column<decimal>(nullable: false),
                    Ancho = table.Column<decimal>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    IsWaterProof = table.Column<bool>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiquetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Stock = table.Column<decimal>(nullable: false),
                    IsRawProduct = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoProductos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProductos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncargadosEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Ci = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncargadosEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncargadosEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    MontoTotal = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Encargado = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    EtiquetaId = table.Column<int>(nullable: true),
                    EnvaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Envases_EnvaseId",
                        column: x => x.EnvaseId,
                        principalTable: "Envases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Presentaciones_Etiquetas_EtiquetaId",
                        column: x => x.EtiquetaId,
                        principalTable: "Etiquetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 50, nullable: false),
                    Ci = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<int>(nullable: true),
                    FaseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    LineaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorias_Lineas_LineaId",
                        column: x => x.LineaId,
                        principalTable: "Lineas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    CategoriaId = table.Column<int>(nullable: true),
                    TipoProductoId = table.Column<int>(nullable: true),
                    SaborId = table.Column<int>(nullable: true),
                    PresentacionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Presentaciones_PresentacionId",
                        column: x => x.PresentacionId,
                        principalTable: "Presentaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_TipoProductos_TipoProductoId",
                        column: x => x.TipoProductoId,
                        principalTable: "TipoProductos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoReal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    stock = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoReal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoReal_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InventarioEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Stock = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true),
                    ProductoRealId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioEmpresas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventarioEmpresas_ProductoReal_ProductoRealId",
                        column: x => x.ProductoRealId,
                        principalTable: "ProductoReal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    estado = table.Column<string>(nullable: true),
                    NumeroFase = table.Column<int>(nullable: false),
                    ProductoRealId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_ProductoReal_ProductoRealId",
                        column: x => x.ProductoRealId,
                        principalTable: "ProductoReal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoPagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Monto = table.Column<decimal>(nullable: false),
                    UnidadesPagadas = table.Column<int>(nullable: false),
                    PagoId = table.Column<int>(nullable: true),
                    ProductoRealId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoPagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoPagos_Pagos_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pagos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoPagos_ProductoReal_ProductoRealId",
                        column: x => x.ProductoRealId,
                        principalTable: "ProductoReal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Porcentaje = table.Column<decimal>(nullable: false),
                    InsumoId = table.Column<int>(nullable: true),
                    ProductoRealId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recetas_ProductoReal_ProductoRealId",
                        column: x => x.ProductoRealId,
                        principalTable: "ProductoReal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaProduccion = table.Column<DateTime>(nullable: false),
                    PedidoId = table.Column<int>(nullable: true),
                    FaseId = table.Column<int>(nullable: true),
                    EmpleadoProducciónId = table.Column<int>(nullable: true),
                    InsumoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producciones_Personas_EmpleadoProducciónId",
                        column: x => x.EmpleadoProducciónId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producciones_Fases_FaseId",
                        column: x => x.FaseId,
                        principalTable: "Fases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producciones_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producciones_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deshechos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deshechos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deshechos_Producciones_Id",
                        column: x => x.Id,
                        principalTable: "Producciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsumoUsados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadUsada = table.Column<decimal>(nullable: false),
                    InsumoId = table.Column<int>(nullable: true),
                    ProduccionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoUsados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsumoUsados_Insumos_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsumoUsados_Producciones_ProduccionId",
                        column: x => x.ProduccionId,
                        principalTable: "Producciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Producciones_Id",
                        column: x => x.Id,
                        principalTable: "Producciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_LineaId",
                table: "Categorias",
                column: "LineaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncargadosEmpresas_EmpresaId",
                table: "EncargadosEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Etiquetas_Nombre",
                table: "Etiquetas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insumos_Nombre",
                table: "Insumos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsumoUsados_InsumoId",
                table: "InsumoUsados",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoUsados_ProduccionId",
                table: "InsumoUsados",
                column: "ProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEmpresas_EmpresaId",
                table: "InventarioEmpresas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioEmpresas_ProductoRealId",
                table: "InventarioEmpresas",
                column: "ProductoRealId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineas_Nombre",
                table: "Lineas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_EmpresaId",
                table: "Pagos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ProductoRealId",
                table: "Pedidos",
                column: "ProductoRealId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_FaseId",
                table: "Personas",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_EnvaseId",
                table: "Presentaciones",
                column: "EnvaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_EtiquetaId",
                table: "Presentaciones",
                column: "EtiquetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Presentaciones_Nombre",
                table: "Presentaciones",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_EmpleadoProducciónId",
                table: "Producciones",
                column: "EmpleadoProducciónId");

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_FaseId",
                table: "Producciones",
                column: "FaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_InsumoId",
                table: "Producciones",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_PedidoId",
                table: "Producciones",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPagos_PagoId",
                table: "ProductoPagos",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPagos_ProductoRealId",
                table: "ProductoPagos",
                column: "ProductoRealId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoReal_ProductoId",
                table: "ProductoReal",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PresentacionId",
                table: "Productos",
                column: "PresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SaborId",
                table: "Productos",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_InsumoId",
                table: "Recetas",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ProductoRealId",
                table: "Recetas",
                column: "ProductoRealId");

            migrationBuilder.CreateIndex(
                name: "IX_Sabores_Nombre",
                table: "Sabores",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_EmpresaId",
                table: "Sucursales",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoProductos_Nombre",
                table: "TipoProductos",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deshechos");

            migrationBuilder.DropTable(
                name: "EncargadosEmpresas");

            migrationBuilder.DropTable(
                name: "InsumoUsados");

            migrationBuilder.DropTable(
                name: "InventarioEmpresas");

            migrationBuilder.DropTable(
                name: "ProductoPagos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Producciones");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Insumos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Fases");

            migrationBuilder.DropTable(
                name: "ProductoReal");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Presentaciones");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "TipoProductos");

            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Envases");

            migrationBuilder.DropTable(
                name: "Etiquetas");
        }
    }
}
