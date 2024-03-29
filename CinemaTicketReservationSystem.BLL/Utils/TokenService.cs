﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using CinemaTicketReservationSystem.BLL.Abstract.Utils;
using CinemaTicketReservationSystem.BLL.Models.Domain.TokenModels;
using CinemaTicketReservationSystem.BLL.Models.Results.Authorize;
using CinemaTicketReservationSystem.DAL.Abstract;
using CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity;

namespace CinemaTicketReservationSystem.BLL.Utils
{
    public class TokenService : ITokenService
    {
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IRepository<RefreshToken> _repository;

        public TokenService(IJwtService jwtService, IRefreshTokenService refreshTokenService, IRepository<RefreshToken> repository)
        {
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _repository = repository;
        }

        public async Task<TokenResult> GenerateTokens(TokenUserModel tokenUserModel)
        {
            JwtSecurityToken token;
            RefreshToken refreshToken;
            try
            {
                token = _jwtService.Generate(tokenUserModel);
                refreshToken = _refreshTokenService.Generate(token.Id, tokenUserModel.Id);
            }
            catch (Exception e)
            {
                return new TokenResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            if (!await _repository.CreateAsync(refreshToken))
            {
                return new TokenResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while adding to the database"
                    }
                };
            }

            return new TokenResult
            {
                JwtToken = jwtToken,
                RefreshToken = refreshToken,
                Success = true
            };
        }

        public async Task<TokenResult> RefreshJwtToken(TokenUserModel tokenUserModel, RefreshToken refreshToken)
        {
            if (!_refreshTokenService.Validate(refreshToken))
            {
                await _repository.RemoveAndSaveAsync(refreshToken);
                return new TokenResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "Token has expired"
                    }
                };
            }

            JwtSecurityToken token;
            try
            {
                token = _jwtService.Generate(tokenUserModel);
            }
            catch (Exception e)
            {
                return new TokenResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        e.Message
                    }
                };
            }

            refreshToken.JwtId = token.Id;
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            if (!await _repository.UpdateAsync(refreshToken))
            {
                return new TokenResult
                {
                    Success = false,
                    Errors = new[]
                    {
                        "An error occured while updating to the database"
                    }
                };
            }

            return new TokenResult
            {
                JwtToken = jwtToken,
                RefreshToken = refreshToken,
                Success = true
            };
        }
    }
}