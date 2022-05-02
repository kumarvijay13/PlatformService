using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{

 public interface ICommandDataClien
 {
     Task SendPlatformToCommand(PlatformReadDtos plat);
     
 }

}

