﻿using CDP.API.Extensions;
using CDP.API.Helpers;
using CDP.Application.Contracts;
using CDP.Application.Dtos;
using CDP.Persistence.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CDP.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FarmController : Controller
    {
        private readonly IFarmService _farmService;
        private readonly IUtil _util;
        private readonly IAccountService _accountService;
        private readonly string _destino = "FarmImage";

        public FarmController(IFarmService farmService, IUtil util, IAccountService accountService)
        {
            _farmService = farmService;
            _util = util;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            try
            {
                var farms = await _farmService.GetAllFarmsAsync(User.GetUserId(), pageParams);
                if (farms == null) return NoContent();

                Response.AddPagination(farms.CurrentPage, farms.PageSize, farms.TotalCount, farms.TotalPages);

                return Ok(farms);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar farms. Erro: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var farm = await _farmService.GetFarmByIdAsync(User.GetUserId(), id);
                if (farm == null) return NoContent();

                return Ok(farm);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Farms. Erro: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(FarmDto model)
        {
            try
            {
                var farm = await _farmService.AddFarms(User.GetUserId(), model);
                if (farm == null) return NoContent();

                return Ok(farm);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Farms. Erro: {ex.Message}");
            }
        }

        [HttpPost("upload-image/{farmId}")]
        public async Task<IActionResult> UploadImage(int farmId)
        {
            try
            {
                var farm = await _farmService.GetFarmByIdAsync(User.GetUserId(), farmId);
                if (farm == null) return NoContent();

                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                    _util.DeleteImage(farm.ImageURL, _destino);
                    farm.ImageURL = await _util.SaveImage(file, _destino);
                }
                var FarmRetorno = await _farmService.UpdateFarm(User.GetUserId(), farmId, farm);

                return Ok(FarmRetorno);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Farms. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, FarmDto model)
        {
            try
            {
                var farm = await _farmService.UpdateFarm(User.GetUserId(), id, model);
                if (farm == null) return NoContent();

                return Ok(farm);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar Farms. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var farm = await _farmService.GetFarmByIdAsync(User.GetUserId(), id);
                if (farm == null) return NoContent();


                if (await _farmService.DeleteFarm(User.GetUserId(), id))
                {
                    _util.DeleteImage(farm.ImageURL, _destino);
                    return Ok(new { message = "Deletado" });
                }
                else
                {
                    throw new Exception("Ocorreu um problema não especifico ao tentar deletar Farm.");
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Farms. Erro: {ex.Message}");
            }
        }
    }
}
