using api;
using api.Data;
using api.Interfaces;
using api.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContextFactory<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFinanceGoalRepository, FinanceGoalRepository>();

//builder.Services.AddScoped<IBankAccountRepository, BankAccountRepository>();

//builder.Services.AddScoped<ICreditCardRepository, CreditCardRepository>();
//builder.Services.AddScoped<IEarningRepository, EarningRepository>();
//builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();

//builder.Services.AddScoped<IMortgageLoanRepository, MortgageLoanRepository>();
//builder.Services.AddScoped<IPersonalCreditRepository, PersonalCreditRepository>();
//builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();



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