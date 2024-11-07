using AutoMapper;
using Core.Repository;
using Moq;
using TodoList.Service.Rules;
using TodoList.Service.Services.Abstracts;
using TodoList.Service.Services.Concretes;


namespace Service.Test;

public class AuthServiceTest
{
    private AuthService _postService;
    private Mock<IAuthService> _userManager;
    private Mock<IMapper> _mapper;
    private Mock<UserBusinessRules> _signInManager;


    [SetUp]
    public void SetUp()
    {
       
        
        _userManager = new Mock<IAuthService>();
        _mapper = new Mock<IMapper>();
        _signInManager = new Mock<UserBusinessRules>(_signInManager.Object);

       // _postService = new AuthService(_postService.Object,_mockMapper.Object,_mockRules.Object);
    }
    

    
   
        
}