namespace RealEstateApp.api.Extensions
{
    public static class RoleServiceExtensions
    {
        public static IServiceCollection AddRoleServices(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagerOnly", policy =>
                policy.RequireClaim("Role", "Manager"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RegisteredUserOnly", policy =>
                policy.RequireClaim("Role", "RegisteredUser"));
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("UnregisteredCustomerOnly", policy =>
                policy.RequireClaim("Role", "UnregisteredCustomer"));
            });
            return services;
        }
    }
}
