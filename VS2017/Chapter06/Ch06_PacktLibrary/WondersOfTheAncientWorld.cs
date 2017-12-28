using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.CS7
{
    [System.Flags]
    public enum WondersOfTheAncientWorld : byte
    {
        None = 0,
        GreatPyramidOfGiza = 1,             //기자의 대피라미드
        HangingGardensOfBabylon = 1 << 1,   //바빌론의 공중 정원
        StatueOfZeusAtOlympia = 1 << 2,     //올림피아의 제우스 상
        TempleOfArtemisAtEphesus = 1 << 3,  //에페소스의 아르테미스 신전
        MausoleumAtHalicarnassus = 1 << 4,  //마우솔로스의 영묘
        ColossusOfRhodes = 1 << 5,          //로도스의 거상
        LighthouseOfAlexandria = 1 << 6     //알렉산드리아의 등대
    }
} 


    


