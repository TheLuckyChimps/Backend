using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Common;
using TPL.Data.Dtos.ProductDtos;
using TPL.Data.Dtos.TransactionDtos;
using TPL.Data.Entities;
using TPL.Data.Enums;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly IProductRepository productRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly string jwt;

        public ProductService(IMapper mapper, IProductRepository productRepository, IConfigurationService configurationService, ITransactionRepository transactionRepository)
        {
            this.mapper = mapper;
            jwt = configurationService.GetJwt();
            this.productRepository = productRepository;
            this.transactionRepository = transactionRepository;
        }
        public async Task<ProductResponseDto> CreateProduct(ProductCreateDto product)
        {
            var auth = await GetUserFromToken(jwt);
            if (auth.Role == UserRole.Admin.ToString())
            {
                // get lines
                var station = mapper.Map<ProductCreateDto, Product>(product);
                //station.Lines.Add(line);
                //station.Line
                var createdProduct = await productRepository.InsertAsync(station, auth.Id);
                var result = mapper.Map<Product, ProductResponseDto>(createdProduct);

                return result;
            }
            else
            {
                throw new Exception("Not allowed");
            }
        }

        public async Task<TransactionResponseDto> CreateTransaction(Guid productId)
        {
            var auth = await GetUserFromToken(jwt);
            if (auth.Role == UserRole.Admin.ToString() || auth.Role == UserRole.Client.ToString())
            {
                // get lines
                var transaction = new Transaction()
                {
                    ProductId = productId,
                    UserId = auth.Id
                };
                //var transaction = mapper.Map<TransactionCreateDto, Transaction>(transactionDto);
                //station.Lines.Add(line);
                //station.Line
                var createdProduct = await transactionRepository.InsertAsync(transaction, auth.Id);
                var result = mapper.Map<Transaction, TransactionResponseDto>(createdProduct);

                return result;
            }
            else
            {
                throw new Exception("Not allowed");
            }
        }

        public async Task<ProductResponseDto> DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {

                var products = await productRepository.GetAllAsync();

                List<ProductResponseDto> productResponse = new List<ProductResponseDto>();

                foreach (Product product in products)
                {
                    var userResponse = mapper.Map<ProductResponseDto>(product);
                    productResponse.Add(userResponse);
                }
                return productResponse;

        }

        public async Task<ProductResponseDto> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenData> GetUserFromToken(string jwt)
        {
            var response = new TokenData();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(jwt);
            response.Id = Guid.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == "id").Value);
            response.Role = jwtSecurityToken.Claims.First(claim => claim.Type == "role").Value;
            //User user = await userRepository.GetByIdAsync(new Guid(id));

            return response;
        }
    }
}
