using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAW_Lab2_Sgr15.Models;
using DAW_Lab2_Sgr15.Models.DTOs;
using DAW_Lab2_Sgr15.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace DAW_Lab2_Sgr15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PlaylistController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetPlaylistById(int id)
        {
            var playlist = await _repository.Playlist.GetByIdAsync(id);

            if (playlist == null)
            {
                return NotFound("Playlist does not exist");
            }
            return Ok(new PlaylistDTO(playlist));
        }


        [HttpGet("user/{userId}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetPlaylistsOfUser(int userId)
        {
            List<Playlist> playlistsOfUser = await _repository.Playlist.GetAllPlaylistsOfUser(userId);

            List<PlaylistDTO> playlistsToReturn = playlistsOfUser.Select(pl => new PlaylistDTO(pl)).ToList();

            return Ok(playlistsToReturn);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var playlist = await _repository.Playlist.GetByIdAsync(id);

            if (playlist == null)
            {
                return NotFound("Playlist does not exist");
            }

            _repository.Playlist.Delete(playlist);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistDTO dto)
        {
            Playlist newPlaylist = new Playlist();

            newPlaylist.Name = dto.Name;
            newPlaylist.UserId = dto.UserId;

            _repository.Playlist.Create(newPlaylist);

            await _repository.SaveAsync();

            return Ok(new PlaylistDTO(newPlaylist));
        }

        [HttpPatch("{id}/{songId}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> AddSongToPlaylist(int songId, int id)
        {
            Playlist playlistToChange = await _repository.Playlist.GetByIdAsync(id);

            await _repository.Playlist.AddSongToPlaylist(playlistToChange, songId);

            _repository.Playlist.Update(playlistToChange);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}
