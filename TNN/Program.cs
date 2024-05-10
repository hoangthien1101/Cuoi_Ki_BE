using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TNN.Data;
using TNN.DataReader;
using TNN.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Nhập Token vào ",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

//Khai bao ket noi
builder.Services.AddDbContext<CuaHangDienLanhContext>(o
    => o.UseSqlServer(builder.Configuration.GetConnectionString("DbContext")));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // xác minh chữ ký xác thực token có hợp lệ không
        ValidateAudience = false, // xác minh địa chỉ nhận
        ValidateIssuer = false, // xác minh địa chỉ gửi
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("Jwt:SecretKey").Value!)) // khóa xác thực
    };
});

builder.Services.AddScoped<ILoaiTaiKhoanRepo, LoaiTaiKhoanRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IWriteFileRepository, WriteFileRepository>();
builder.Services.AddScoped<ISendMailService, SendEmailService>();
builder.Services.AddScoped<IUpLoadHinhAnhRepo, UpLoadHinhAnhRepo>();
builder.Services.AddScoped<ILoginService, LoginServices>();
builder.Services.AddScoped<ITokenServices, TokenServices>();
builder.Services.AddScoped<ISanPhamRepo, SanPhamRepo>();
builder.Services.AddScoped<IHangRepo, HangRepo>();
builder.Services.AddScoped<ILoaiSanPhamRepo, LoaiSanPhamRepo>();
builder.Services.AddScoped<IHoaDonRepo, HoaDonRepo>();
builder.Services.AddScoped<IChiTietHoaDonRepo, ChiTietHoaDonRepo>();
builder.Services.AddScoped<INhaCungCapRepo, NhaCungCapRepo>();
builder.Services.AddScoped<IGioHangRepo, GioHangRepo>();
builder.Services.AddScoped<IChiTietGioHangRepo, ChiTietGioHangRepo>();
builder.Services.AddScoped<IChiTietDonNhapRepo, ChiTietDonNhapRepo>();
builder.Services.AddScoped<IDonNhapRepo, DonNhapRepo>();


//builder.Services.AddSingleton<Database>();
builder.Services.AddSingleton<DataDapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
