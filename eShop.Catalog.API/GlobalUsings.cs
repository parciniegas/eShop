// Global using directives

global using eShop.Catalog.API.Config;
global using eShop.Catalog.API.Middleware;
global using eShop.Catalog.Application.Brands.Commands.Add;
global using eShop.Catalog.Infrastructure.Repository.EntityFramework;
global using FluentValidation;
global using Ilse.CorrelationId.DependencyInjection;
global using Ilse.CorrelationId.Middleware;
global using Ilse.Cqrs.Commands;
global using Ilse.Cqrs.Queries;
global using Ilse.Events.DependencyInjection;
global using Ilse.MinimalApi;
global using Ilse.Repository.Abstracts;
global using Ilse.Repository.Contracts;
global using Ilse.Repository.Implementations;
global using Ilse.TenantContext.Context;
global using Ilse.TenantContext.DependencyInjection;
global using Ilse.TenantContext.Middleware;
global using MassTransit;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Net.Http.Headers;
global using Microsoft.OpenApi.Models;
global using NLog.Web;