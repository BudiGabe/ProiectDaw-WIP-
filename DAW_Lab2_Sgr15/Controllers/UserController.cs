using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Data;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Models.DTOs;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace DAW_Lab2_Sgr15.Controllers
{

    /*
     * Needed:
     *   GetAll
     *   GetById
     *   Update
     *   Delete
     *   Create
     */
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public UserController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }


        [HttpGet("playlists")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsersWithPlaylists()
        {
            var users = await _repository.User.GetAllUsersWithPlaylists();

            var usersToReturn = new List<UserPlaylistDTO>();

            foreach (var user in users)
            {
                usersToReturn.Add(new UserPlaylistDTO(user));
            }

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _repository.User.GetByIdAsync(id);
            return Ok(new UserDTO(user));
        }

        [HttpGet("{id}/playlists")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetUserByIdWithPlaylists(int id)
        {
            var user = await _repository.User.GetUserByIdWithPlaylists(id);
            return Ok(new UserPlaylistDTO(user));
        }

        [HttpGet("{id}/info")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetUserByIdWithInfo(int id)
        {
            var user = await _repository.User.GetByIdWithInfo(id);
            return Ok(new UserDTO(user));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _repository.User.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound("User does not exist");
            }

            _repository.User.Delete(user);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreateUser(CreateUserDTO dto)
        {
            User newUser = new User();

            newUser.Name = dto.Name;
            newUser.PersonalInfo = dto.PersonalInfo;

            _repository.User.Create(newUser);

            await _repository.SaveAsync();

            return Ok(new UserDTO(newUser));
        }

        [HttpPatch]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateUserPersonalInfo([FromBody] UserWithInfoDTO dto)
        {
            User userToChange = await _repository.User.GetByIdWithInfo(dto.Id);

            if (userToChange.PersonalInfo == null)
            {
                userToChange.PersonalInfo = dto.PersonalInfo;
            }
            else
            {
                userToChange.PersonalInfo.Age = dto.PersonalInfo.Age;
                userToChange.PersonalInfo.Sex = dto.PersonalInfo.Sex;

            }

            _repository.User.Update(userToChange);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}/{songId}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> AddSongToUser(int songId, int id)
        {
            User userToChange = await _repository.User.GetByIdAsync(id);

            var added = await _repository.User.AddSongToUser(userToChange, songId);

            if (added)
            {
                _repository.User.Update(userToChange);
                await _repository.SaveAsync();

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
