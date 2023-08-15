﻿using AutoMapper;

using ROH.Domain.Version;
using ROH.Interfaces.Repository.Version;
using ROH.Interfaces.Services.Version;
using ROH.StandardModels.Response;
using ROH.StandardModels.Version;

namespace ROH.Services.Version
{
    public class GameVersionService : IGameVersionService
    {
        private readonly IGameVersionRepository _versionRepository;
        private readonly IMapper _mapper;

        public GameVersionService(IGameVersionRepository versionRepository, IMapper mapper)
        {
            _versionRepository = versionRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse?> GetVersionById(long idVersion)
        {
            GameVersion? version = await _versionRepository.GetVersionById(idVersion);
            GameVersionModel model = _mapper.Map<GameVersionModel>(version);
            return new DefaultResponse() { ObjectResponse = model };
        }

        public async Task<DefaultResponse> GetAllVersions()
        {
            IList<GameVersion>? versions = await _versionRepository.GetAllVersions();
            return new DefaultResponse(objectResponse: versions);
        }

        public async Task<DefaultResponse> GetAllReleasedVersions()
        {
            IList<GameVersion>? versions = await _versionRepository.GetAllReleasedVersions();

            return new DefaultResponse(objectResponse: versions, message: "That are all released versions");
        }

        public async Task<DefaultResponse> NewVersion(GameVersionModel version)
        {
            bool valid = await VerifyIfVersionExist(version);
            if (valid)
            {
                return new DefaultResponse(httpStatus: System.Net.HttpStatusCode.Conflict,
                                           message: "This version already exist.");
            }

            _ = await _versionRepository.SetNewGameVersion(_mapper.Map<GameVersion>(version));

            return new DefaultResponse(message: "New game version created.");
        }

        public async Task<bool> VerifyIfVersionExist(GameVersionModel version)
        {
            GameVersion versionModel = _mapper.Map<GameVersion>(version);
            IList<GameVersion>? versions = await _versionRepository.GetAllVersions();
            return versions != null && versions.Count > 0 && versions.Any(v => v == versionModel);
        }

        public async Task<DefaultResponse> GetCurrentVersion()
        {
            GameVersion? version = await _versionRepository.GetCurrentGameVersion();
            return new DefaultResponse(objectResponse: version);
        }
    }
}