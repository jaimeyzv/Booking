using Payment.Infrastructure.Interfaces.Mappers;

namespace Payment.Infrastructure.Mappers
{
    public class Mapper : IMapper
    {
    //    #region Profile

    //    public ProfileDto MapFromEntityToDto(ProfileEntity entity)
    //    {
    //        return new ProfileDto()
    //        {
    //            ProfileId = entity.ProfileId,
    //            Code = entity.Code,
    //            Description = entity.Description,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    public ProfileEntity MapFromDtoToEntity(ProfileDto dto)
    //    {
    //        return new ProfileEntity()
    //        {
    //            ProfileId = dto.ProfileId,
    //            Code = dto.Code,
    //            Description = dto.Description,
    //            IsActive = dto.IsActive
    //        };
    //    }

    //    public ProfileEntity MapFromModelToEntity(ProfileModel model)
    //    {
    //        return new ProfileEntity()
    //        {
    //            ProfileId = model.ProfileId,
    //            Code = model.Code,
    //            Description = model.Description,
    //            IsActive = model.IsActive
    //        };
    //    }

    //    public ProfileModel MapFromEntityToModel(ProfileEntity entity)
    //    {
    //        return new ProfileModel()
    //        {
    //            ProfileId = entity.ProfileId,
    //            Code = entity.Code,
    //            Description = entity.Description,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    #endregion

    //    #region Permission

    //    public PermissionDto MapFromEntityToDto(PermissionEntity entity)
    //    {
    //        return new PermissionDto()
    //        {
    //            PermissionId = entity.PermissionId,
    //            Description = entity.Description,
    //            IsActive = entity.IsActive,
    //            ProfileId = entity.ProfileId,
    //            Text = entity.Text,
    //            ImageUrl = entity.ImageUrl,
    //            Screen= entity.Screen
    //        };
    //    }

    //    public PermissionEntity MapFromDtoToEntity(PermissionDto dto)
    //    {
    //        return new PermissionEntity()
    //        {
    //            PermissionId = dto.PermissionId,
    //            Description = dto.Description,
    //            IsActive = dto.IsActive,
    //            ProfileId = dto.ProfileId,
    //            Text = dto.Text,
    //            ImageUrl = dto.ImageUrl,
    //            Screen = dto.Screen

    //        };
    //    }

    //    public PermissionEntity MapFromModelToEntity(PermissionModel model)
    //    {
    //        return new PermissionEntity()
    //        {
    //            PermissionId = model.PermissionId,
    //            Description = model.Description,
    //            IsActive = model.IsActive,
    //            ProfileId = model.ProfileId,
    //            Text = model.Text,
    //            ImageUrl = model.ImageUrl,
    //            Screen = model.Screen
    //        };
    //    }

    //    public PermissionModel MapFromEntityToModel(PermissionEntity entity)
    //    {
    //        return new PermissionModel()
    //        {
    //            PermissionId = entity.PermissionId,
    //            Description = entity.Description,
    //            IsActive = entity.IsActive,
    //            ProfileId = entity.ProfileId,
    //            Text = entity.Text,
    //            ImageUrl = entity.ImageUrl,
    //            Screen = entity.Screen
    //        };
    //    }

    //    #endregion

    //    #region Mobile

    //    public MobileEntity MapFromDtoToEntity(MobileDto dto)
    //    {
    //        return new MobileEntity()
    //        {
    //            MobileId = dto.MobileId,
    //            Description = dto.Description,
    //            Imei = dto.Imei,
    //            IsActive = dto.IsActive
    //        };
    //    }

    //    public MobileDto MapFromEntityToDto(MobileEntity entity)
    //    {
    //        return new MobileDto()
    //        {
    //            MobileId = entity.MobileId,
    //            Description = entity.Description,
    //            Imei = entity.Imei,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    public MobileModel MapFromEntityToModel(MobileEntity entity)
    //    {
    //        return new MobileModel()
    //        {
    //            MobileId = entity.MobileId,
    //            Description = entity.Description,
    //            Imei = entity.Imei,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    public MobileEntity MapFromModelToEntity(MobileModel model)
    //    {
    //        return new MobileEntity()
    //        {
    //            MobileId = model.MobileId,
    //            Description = model.Description,
    //            Imei = model.Imei,
    //            IsActive = model.IsActive
    //        };
    //    }

    //    #endregion

    //    #region Department

    //    public DepartmentDto MapFromEntityToDto(DepartmentEntity entity)
    //    {
    //        return new DepartmentDto()
    //        {
    //            DepartmentId = entity.DepartmentId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    public DepartmentEntity MapFromDtoToEntity(DepartmentDto dto)
    //    {
    //        return new DepartmentEntity()
    //        {
    //            DepartmentId = dto.DepartmentId,
    //            Name = dto.Name,
    //            IsActive = dto.IsActive
    //        };
    //    }

    //    public DepartmentEntity MapFromModelToEntity(DepartmentModel model)
    //    {
    //        return new DepartmentEntity()
    //        {
    //            DepartmentId = model.DepartmentId,
    //            Name = model.Name,
    //            IsActive = model.IsActive
    //        };
    //    }

    //    public DepartmentModel MapFromEntityToModel(DepartmentEntity entity)
    //    {
    //        return new DepartmentModel()
    //        {
    //            DepartmentId = entity.DepartmentId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive
    //        };
    //    }

    //    #endregion

    //    #region RegionalTeam

    //    public RegionalTeamDto MapFromEntityToDto(RegionalTeamEntity entity)
    //    {
    //        return new RegionalTeamDto()
    //        {
    //            RegionalTeamId = entity.RegionalTeamId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive,
    //            DepartmentId = entity.DepartmentId
    //        };
    //    }

    //    public RegionalTeamEntity MapFromDtoToEntity(RegionalTeamDto dto)
    //    {
    //        return new RegionalTeamEntity()
    //        {
    //            RegionalTeamId = dto.RegionalTeamId,
    //            Name = dto.Name,
    //            IsActive = dto.IsActive,
    //            DepartmentId = dto.DepartmentId
    //        };
    //    }

    //    public RegionalTeamEntity MapFromModelToEntity(RegionalTeamModel model)
    //    {
    //        return new RegionalTeamEntity()
    //        {
    //            RegionalTeamId = model.RegionalTeamId,
    //            Name = model.Name,
    //            IsActive = model.IsActive,
    //            DepartmentId = model.DepartmentId
    //        };
    //    }

    //    public RegionalTeamModel MapFromEntityToModel(RegionalTeamEntity entity)
    //    {
    //        return new RegionalTeamModel()
    //        {
    //            RegionalTeamId = entity.RegionalTeamId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive,
    //            DepartmentId = entity.DepartmentId
    //        };
    //    }

    //    #endregion

    //    #region User

    //    public UserDto MapFromEntityToDto(UserEntity entity)
    //    {
    //        return new UserDto()
    //        {
    //            UserId = entity.UserId,
    //            UserName = entity.UserName,
    //            Password = entity.Password,
    //            Name = entity.Name,
    //            Lastname = entity.Lastname,
    //            IdentityDocumentType = entity.IdentityDocumentType,
    //            IdentityDocumentNumber = entity.IdentityDocumentNumber,
    //            BirthDate = entity.BirthDate,
    //            Gender = entity.Gender,
    //            Email = entity.Email,
    //            ProfileId = entity.ProfileId,
    //            IsActive = entity.IsActive,
    //            AssignedMobileId = entity.AssignedMobileId,
    //            RegionalTeamId = entity.RegionalTeamId
    //        };
    //    }

    //    public UserEntity MapFromDtoToEntity(UserDto dto)
    //    {
    //        return new UserEntity()
    //        {
    //            UserId = dto.UserId,
    //            UserName = dto.UserName,
    //           // Password = dto.Password,
    //            Name = dto.Name,
    //            Lastname = dto.Lastname,
    //            IdentityDocumentType = dto.IdentityDocumentType,
    //            IdentityDocumentNumber = dto.IdentityDocumentNumber,
    //            BirthDate = dto.BirthDate,
    //            Gender = dto.Gender,
    //            Email = dto.Email,
    //            ProfileId = dto.ProfileId,
    //            IsActive = dto.IsActive,
    //            AssignedMobileId = dto.AssignedMobileId,
    //            RegionalTeamId = dto.RegionalTeamId
    //        };
    //    }

    //    public UserEntity MapFromModelToEntity(UserModel model)
    //    {
    //        return new UserEntity()
    //        {
    //            UserId = model.UserId,
    //            UserName = model.UserName,
    //            Password = model.Password,
    //            Name = model.Name,
    //            Lastname = model.Lastname,
    //            IdentityDocumentType = model.IdentityDocumentType,
    //            IdentityDocumentNumber = model.IdentityDocumentNumber,
    //            BirthDate = model.BirthDate,
    //            Gender = model.Gender,
    //            Email = model.Email,
    //            ProfileId = model.ProfileId,
    //            IsActive = model.IsActive,
    //            AssignedMobileId = model.AssignedMobileId,
    //            RegionalTeamId = model.RegionalTeamId
    //        };
    //    }

    //    public UserModel MapFromEntityToModel(UserEntity entity)
    //    {
    //        return new UserModel()
    //        {
    //            UserId = entity.UserId,
    //            UserName = entity.UserName,
    //            Password = entity.Password,
    //            Name = entity.Name,
    //            Lastname = entity.Lastname,
    //            IdentityDocumentType = entity.IdentityDocumentType,
    //            IdentityDocumentNumber = entity.IdentityDocumentNumber,
    //            BirthDate = entity.BirthDate,
    //            Gender = entity.Gender,
    //            Email = entity.Email,
    //            ProfileId = entity.ProfileId,
    //            IsActive = entity.IsActive,
    //            AssignedMobileId = entity.AssignedMobileId,
    //            RegionalTeamId = entity.RegionalTeamId
    //        };
    //    }

    //    #endregion

    //    #region Activity

    //    public ActivityDto MapFromEntityToDto(ActivityEntity entity)
    //    {
    //        return new ActivityDto()
    //        {
    //            ActivityId = entity.ActivityId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive,
    //            CreatedDate = entity.CreatedDate,
    //            UpdatedDate = entity.UpdatedDate,
    //            CreatedBy = entity.CreatedBy,
    //            UpdatedBy = entity.UpdatedBy
    //        };
    //    }

    //    public ActivityEntity MapFromDtoToEntity(ActivityDto dto)
    //    {
    //        return new ActivityEntity()
    //        {
    //            ActivityId = dto.ActivityId,
    //            Name = dto.Name,
    //            IsActive = dto.IsActive,
    //            CreatedDate = dto.CreatedDate,
    //            UpdatedDate = dto.UpdatedDate,
    //            CreatedBy = dto.CreatedBy,
    //            UpdatedBy = dto.UpdatedBy
    //        };
    //    }

    //    public ActivityEntity MapFromModelToEntity(ActivityModel model)
    //    {
    //        return new ActivityEntity()
    //        {
    //            ActivityId = model.ActivityId,
    //            Name = model.Name,
    //            IsActive = model.IsActive,
    //            CreatedDate = model.CreatedDate,
    //            UpdatedDate = model.UpdatedDate,
    //            CreatedBy = model.CreatedBy,
    //            UpdatedBy = model.UpdatedBy
    //        };
    //    }

    //    public ActivityModel MapFromEntityToModel(ActivityEntity entity)
    //    {
    //        return new ActivityModel()
    //        {
    //            ActivityId = entity.ActivityId,
    //            Name = entity.Name,
    //            IsActive = entity.IsActive,
    //            CreatedDate = entity.CreatedDate,
    //            UpdatedDate = entity.UpdatedDate,
    //            CreatedBy = entity.CreatedBy,
    //            UpdatedBy = entity.UpdatedBy
    //        };
    //    }

    //    #endregion

    //    #region Activity By User

    //    public ActivityByUserDto MapFromEntityToDto(ActivityByUserEntity entity)
    //    {
    //        return new ActivityByUserDto()
    //        {
    //            ActivityByUserId = entity.ActivityByUserId,
    //            StartDate = entity.StartDate,
    //            EndDate = entity.EndDate,
    //            InitialGpsLocation = entity.InitialGpsLocation,
    //            FinalGpsLocation = entity.FinalGpsLocation,
    //            ActivityId = entity.ActivityId,
    //            UserId = entity.UserId,
    //            CreatedDate = entity.CreatedDate,
    //            CreatedBy = entity.CreatedBy,
    //            UpdatedBy = entity.UpdatedBy
    //        };
    //}

    //    public ActivityByUserEntity MapFromDtoToEntity(ActivityByUserDto dto)
    //    {
    //        return new ActivityByUserEntity()
    //        {
    //            ActivityByUserId = dto.ActivityByUserId,
    //            StartDate = dto.StartDate,
    //            EndDate = dto.EndDate,
    //            InitialGpsLocation = dto.InitialGpsLocation,
    //            FinalGpsLocation = dto.FinalGpsLocation,
    //            ActivityId = dto.ActivityId,
    //            UserId = dto.UserId,
    //            CreatedDate = dto.CreatedDate,
    //            CreatedBy = dto.CreatedBy,
    //            UpdatedBy = dto.UpdatedBy
    //        };
    //    }

    //    public ActivityByUserEntity MapFromModelToEntity(ActivityByUserModel model)
    //    {
    //        return new ActivityByUserEntity()
    //        {
    //            ActivityByUserId = model.ActivityByUserId,
    //            StartDate = model.StartDate,
    //            EndDate = model.EndDate,
    //            InitialGpsLocation = model.InitialGpsLocation,
    //            FinalGpsLocation = model.FinalGpsLocation,
    //            ActivityId = model.ActivityId,
    //            UserId = model.UserId
    //        };
    //    }

    //    public ActivityByUserModel MapFromEntityToModel(ActivityByUserEntity entity)
    //    {
    //        return new ActivityByUserModel()
    //        {
    //            ActivityByUserId = entity.ActivityByUserId,
    //            StartDate = entity.StartDate,
    //            EndDate = entity.EndDate,
    //            InitialGpsLocation = entity.InitialGpsLocation,
    //            FinalGpsLocation = entity.FinalGpsLocation,
    //            ActivityId = entity.ActivityId,
    //            UserId = entity.UserId
    //        };
    //    }



    //    #endregion

    //    #region activity User

    //    public ActivityUserDto MapFromEntityToDto(ActivityUserEntity entity)
    //    {
    //        return new ActivityUserDto()
    //        {
    //            Activity_X_User_Id = entity.Activity_X_User_Id,
    //            StartDate = entity.StartDate,
    //            EndDate = entity.EndDate,
    //            InitialGpsLocation = entity.InitialGpsLocation,
    //            FinalGpsLocation = entity.FinalGpsLocation,
    //            ActivityId = entity.ActivityId,
    //            UserId = entity.UserId,
    //            Name = entity.Name
    //        };
    //    }

    //    public ActivityUserEntity MapFromDtoToEntity(ActivityUserDto dto)
    //    {
    //        return new ActivityUserEntity()
    //        {
    //            Activity_X_User_Id = dto.Activity_X_User_Id,
    //            StartDate = dto.StartDate,
    //            EndDate = dto.EndDate,
    //            InitialGpsLocation = dto.InitialGpsLocation,
    //            FinalGpsLocation = dto.FinalGpsLocation,
    //            ActivityId = dto.ActivityId,
    //            UserId = dto.UserId,
    //            Name = dto.Name
    //        };
    //    }

    //    public ActivityUserEntity MapFromModelToEntity(ActivityUserModel model)
    //    {
    //        return new ActivityUserEntity()
    //        {
    //            Activity_X_User_Id = model.ActivityByUserId,
    //            StartDate = model.StartDate,
    //            EndDate = model.EndDate,
    //            InitialGpsLocation = model.InitialGpsLocation,
    //            FinalGpsLocation = model.FinalGpsLocation,
    //            ActivityId = model.ActivityId,
    //            UserId = model.UserId,
    //            Name = model.Name
    //        };
    //    }

    //    public ActivityUserModel MapFromEntityToModel(ActivityUserEntity entity)
    //    {
    //        return new ActivityUserModel()
    //        {
    //            ActivityByUserId = entity.Activity_X_User_Id,
    //            StartDate = entity.StartDate,
    //            EndDate = entity.EndDate,
    //            InitialGpsLocation = entity.InitialGpsLocation,
    //            FinalGpsLocation = entity.FinalGpsLocation,
    //            ActivityId = entity.ActivityId,
    //            UserId = entity.UserId,
    //            Name = entity.Name,
    //            Status = (entity.EndDate == null) ? 1 : 0
    //        };
    //    }


    //    #endregion
    }
}