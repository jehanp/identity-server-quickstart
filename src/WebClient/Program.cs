using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddOpenIdConnectAccessTokenManagement();
builder.Services.AddUserAccessTokenHttpClient("apiClient", configureClient: client =>{
    client.BaseAddress=new Uri("https://localhost:6001");
});

builder.Services.AddAuthentication(options=>{
    options.DefaultScheme="Cookies";
    options.DefaultChallengeScheme="oidc";
})
.AddCookie("Cookies")
.AddOpenIdConnect("oidc", options=>{
    options.Authority="https://localhost:5001";
    
    options.ClientId="web";
    options.ClientSecret="secret";
    options.ResponseType="code";

    options.Scope.Clear();
    options.Scope.Add("openid");
    options.Scope.Add("profile");
    options.Scope.Add("verification");
    options.Scope.Add("api1");
    options.Scope.Add("color");
    options.Scope.Add("offline_access");
    options.ClaimActions.MapJsonKey("email_verified", "email_verified");

    options.GetClaimsFromUserInfoEndpoint=true;
    options.ClaimActions.MapJsonKey("favorite_color", "favorite_color");

    options.MapInboundClaims=false; // Don't rename claim types
    options.SaveTokens=true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets()
   .RequireAuthorization();

app.Run();
