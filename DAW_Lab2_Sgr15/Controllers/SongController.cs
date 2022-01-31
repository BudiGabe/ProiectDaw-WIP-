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
    public class SongController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public SongController(IRepositoryWrapper repo)
        {
            _repository = repo;
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetAllSongsOfUser(int userId)
        {
            List<Song> songsOfUser = await _repository.Song.GetSongsOfUser(userId);

            List<SongDTO> songsToReturn= songsOfUser.Select(song => new SongDTO(song)).ToList();

            return Ok(songsToReturn);
        }

        [HttpGet("playlist/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetAllSongsOfPlaylist(int id)
        {
            List<Song> songsOfPlaylist = await _repository.Song.GetSongsOfPlaylist(id);

            List<SongDTO> songsToReturn = songsOfPlaylist.Select(song => new SongDTO(song)).ToList();

            return Ok(songsToReturn);
        }

        [HttpGet("id/{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetSongById(int id)
        {
            var song = await _repository.Song.GetByIdAsync(id);

            if (song == null)
            {
                return NotFound("Song does not exist");
            }
            return Ok(new SongDTO(song));
        }
        
        [HttpGet("name/{name}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetSongByName(string name)
        {
            var song = await _repository.Song.GetByName(name);

            if (song == null)
            {
                return NotFound("Song does not exist");
            }
            return Ok(new SongDTO(song));
        }

        [HttpGet("exists/{name}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CheckIfExists(string name)
        {
            var exists = await _repository.Song.CheckIfExists(name);
            return Ok(exists);
        }

        [HttpPost]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreateSong(CreateSongDTO dto)
        {
            Song newSong = new Song();
            newSong.Name = dto.Name;
            newSong.Popularity = dto.Popularity;

            _repository.Song.Create(newSong);
            await _repository.SaveAsync();

            return Ok(new SongDTO(newSong));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = await _repository.Song.GetByIdAsync(id);

            if (song == null)
            {
                return NotFound("Song does not exist");
            }

            _repository.Song.Delete(song);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateSongPopularity(int id)
        {
            Song songToChange = await _repository.Song.GetByIdAsync(id);
            songToChange.Popularity = songToChange.Popularity + 1;
            
            _repository.Song.Update(songToChange);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
