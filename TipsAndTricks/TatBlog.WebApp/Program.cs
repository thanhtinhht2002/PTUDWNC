var buider = WebApplication.CreateBuilder(args);
{
    buider.Services.AddControllersWithViews();
}

var app = buider.Build();
{
	if (app.Environment.IsDevelopment())
	{
		app.UseDeveloperExceptionPage();
	}
	else
	{
		app.UseExceptionHandler("/Blog/Error");
		app.UseHsts();
	}
	app.UseHttpsRedirection();

	app.UseStaticFiles();

	app.UseRouting();

	app.MapControllerRoute(
		name: "default",
		pattern: "{controller=Blog}/{action=Index}/{id?}");
}