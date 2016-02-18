﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Thermometer.Interfaces;
using Thermometer.JsonModels;
using Thermometer.Projections;

namespace Thermometer.Infrastructure
{
    internal class FakeWeatherForecastDataProvider : IWeatherForecastDataProvider
    {
        #region Constants

        private const string ResultEn =
            @"{""response"":{""created"":1455753600,""local_time"":1455773889,""gmt_add"":25200,""where"":""Krasnoyarsk"",""where_unique"":"""",""current_weather"":{""archive"":{""archive_string"":""6 hours ago at the weather station (12 km) it was #t, overcast, very high air pressure, high humidity (82%), light breeze #wv, blowing from the west-southwest. Snow shower(s), moderate or heavy."",""temperature"":{""c"":-9.8,""f"":14},""temperature_sea"":{""c"":0,""f"":32},""wind_velocity"":3,""horizontal_v"":0,""vertical_c"":0,""sss"":0,""pr"":{""mm"":null,""inches"":null}},""distance"":12,""last"":1455778800,""source"":""synop"",""temperature"":{""c"":-10,""f"":14},""feel_temperature"":{""c"":-15,""f"":5},""humidity"":82,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":760,""inhg"":29,""mbar"":1013,""hpa"":1013},""pressure_icon"":4,""pressure_hint"":""Very high air pressure"",""cloud_cover"":4,""phenomenon"":2,""wind_velocity"":{""ms"":3,""kmh"":11,""mph"":7,""knots"":6,""bft"":2},""wind_velocity_hint"":""Light breeze"",""wind_direction"":12,""wind_direction_hint"":""WSW"",""wind_gusts"":{""ms"":-1,""kmh"":-1,""mph"":-1,""knots"":-1,""bft"":-1}},""forecast"":{""count"":24,""items"":[[{""gmt"":1455800400,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 100%)"",""decimal"":""Overcast\n(low-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.40000400004,""inches"":0.1570015700157},""fraction"":-1},""precipitation"":{""mm"":0.40000400004,""inches"":0},""precipitation_hint"":{""mm"":""snow (0.4 mm \/ 6 hours)"",""inches"":""snow (0.02 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-8,""f"":18},""feel_temperature"":{""c"":-14,""f"":7},""humidity"":69,""humidity_hint"":""Comfortable humidity"",""pressure"":{""mmhg"":765,""inhg"":30,""mbar"":1019,""hpa"":1019},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":4,""kmh"":14,""mph"":9,""knots"":8,""bft"":3},""wind_gusts"":{""ms"":10,""kmh"":36,""mph"":22,""knots"":19,""bft"":5},""wind_velocity_hint"":""Gentle breeze"",""wind_direction"":366,""wind_direction_hint"":""Wind blowing from the north-west"",""sunrise"":1455782820,""sunset"":1455818259,""moonrise"":""13:27"",""moonset"":""05:02"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 84%""},{""gmt"":1455822000,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 100%)"",""decimal"":""Overcast\n(low-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-10,""f"":14},""feel_temperature"":{""c"":-14,""f"":7},""humidity"":81,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":770,""inhg"":30,""mbar"":1026,""hpa"":1026},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":2,""kmh"":7,""mph"":4,""knots"":4,""bft"":2},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light breeze"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1455782820,""sunset"":1455818259,""moonrise"":""13:27"",""moonset"":""05:02"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 84%""}],[{""gmt"":1455843600,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":76,""decimal"":8,""oktas"":6},""cloud_cover_hint"":{""pct"":""Cloudy\n(mid-level clouds 76%, high-level clouds 84%)"",""decimal"":""Cloudy\n(mid-level clouds 8\/10, high-level clouds 8\/10)"",""oktas"":""Cloudy\n(mid-level clouds 6 oktas, high-level clouds 7 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-13,""f"":9},""feel_temperature"":{""c"":-16,""f"":3},""humidity"":75,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":771,""inhg"":30,""mbar"":1027,""hpa"":1027},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1455782820,""sunset"":1455818259,""moonrise"":""14:27"",""moonset"":""05:52"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 91%""},{""gmt"":1455865200,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":97,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 96%, mid-level clouds 97%, high-level clouds 98%)"",""decimal"":""Mostly cloudy\n(low-level clouds 10\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 8 oktas, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-11,""f"":12},""feel_temperature"":{""c"":-18,""f"":0},""humidity"":75,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":768,""inhg"":30,""mbar"":1023,""hpa"":1023},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":4,""kmh"":14,""mph"":9,""knots"":8,""bft"":3},""wind_gusts"":{""ms"":8,""kmh"":29,""mph"":18,""knots"":16,""bft"":5},""wind_velocity_hint"":""Gentle breeze"",""wind_direction"":364,""wind_direction_hint"":""Wind blowing from the south-west"",""sunrise"":1455869078,""sunset"":1455904789,""moonrise"":""14:27"",""moonset"":""05:52"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 91%""},{""gmt"":1455886800,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 4%, mid-level clouds 100%, high-level clouds 100%)"",""decimal"":""Overcast\n(low-level clouds 1\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 1 okta, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-7,""f"":19},""feel_temperature"":{""c"":-12,""f"":10},""humidity"":63,""humidity_hint"":""Comfortable humidity"",""pressure"":{""mmhg"":764,""inhg"":30,""mbar"":1018,""hpa"":1018},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":3,""kmh"":11,""mph"":7,""knots"":6,""bft"":2},""wind_gusts"":{""ms"":9,""kmh"":32,""mph"":20,""knots"":17,""bft"":5},""wind_velocity_hint"":""Light breeze"",""wind_direction"":364,""wind_direction_hint"":""Wind blowing from the south-west"",""sunrise"":1455869078,""sunset"":1455904789,""moonrise"":""14:27"",""moonset"":""05:52"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 91%""},{""gmt"":1455908400,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":99,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 94%, mid-level clouds 99%, high-level clouds 100%)"",""decimal"":""Mostly cloudy\n(low-level clouds 9\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 8 oktas, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-7,""f"":19},""feel_temperature"":{""c"":-13,""f"":9},""humidity"":70,""humidity_hint"":""Comfortable humidity"",""pressure"":{""mmhg"":760,""inhg"":29,""mbar"":1013,""hpa"":1013},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":4,""kmh"":14,""mph"":9,""knots"":8,""bft"":3},""wind_gusts"":{""ms"":8,""kmh"":29,""mph"":18,""knots"":16,""bft"":5},""wind_velocity_hint"":""Gentle breeze"",""wind_direction"":364,""wind_direction_hint"":""Wind blowing from the south-west"",""sunrise"":1455869078,""sunset"":1455904789,""moonrise"":""14:27"",""moonset"":""05:52"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 91%""}],[{""gmt"":1455930000,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 97%, mid-level clouds 100%, high-level clouds 100%)"",""decimal"":""Overcast\n(low-level clouds 10\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-7,""f"":19},""feel_temperature"":{""c"":-11,""f"":12},""humidity"":77,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":756,""inhg"":29,""mbar"":1007,""hpa"":1007},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":2,""kmh"":7,""mph"":4,""knots"":4,""bft"":2},""wind_gusts"":{""ms"":7,""kmh"":25,""mph"":16,""knots"":14,""bft"":4},""wind_velocity_hint"":""Light breeze"",""wind_direction"":364,""wind_direction_hint"":""Wind blowing from the south-west"",""sunrise"":1455869078,""sunset"":1455904789,""moonrise"":""15:32"",""moonset"":""06:32"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 96%""},{""gmt"":1455951600,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 100%, mid-level clouds 100%, high-level clouds 95%)"",""decimal"":""Overcast\n(low-level clouds 10\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.70000700007,""inches"":0.2760027600276},""fraction"":-1},""precipitation"":{""mm"":0.70000700007,""inches"":0},""precipitation_hint"":{""mm"":""snow (0.7 mm \/ 6 hours)"",""inches"":""snow (0.03 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-9,""f"":16},""feel_temperature"":{""c"":-15,""f"":5},""humidity"":79,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":755,""inhg"":29,""mbar"":1006,""hpa"":1006},""pressure_hint"":""High air pressure"",""wind_velocity"":{""ms"":4,""kmh"":14,""mph"":9,""knots"":8,""bft"":3},""wind_gusts"":{""ms"":8,""kmh"":29,""mph"":18,""knots"":16,""bft"":5},""wind_velocity_hint"":""Gentle breeze"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1455955336,""sunset"":1455991320,""moonrise"":""15:32"",""moonset"":""06:32"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 96%""},{""gmt"":1455973200,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 100%, mid-level clouds 100%, high-level clouds 100%)"",""decimal"":""Overcast\n(low-level clouds 10\/10, mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas, mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.30000300003,""inches"":0.1180011800118},""fraction"":-1},""precipitation"":{""mm"":0.30000300003,""inches"":0},""precipitation_hint"":{""mm"":""snow (0.3 mm \/ 6 hours)"",""inches"":""snow (0.01 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-8,""f"":18},""feel_temperature"":{""c"":-12,""f"":10},""humidity"":69,""humidity_hint"":""Comfortable humidity"",""pressure"":{""mmhg"":755,""inhg"":29,""mbar"":1006,""hpa"":1006},""pressure_hint"":""High air pressure"",""wind_velocity"":{""ms"":2,""kmh"":7,""mph"":4,""knots"":4,""bft"":2},""wind_gusts"":{""ms"":7,""kmh"":25,""mph"":16,""knots"":14,""bft"":4},""wind_velocity_hint"":""Light breeze"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1455955336,""sunset"":1455991320,""moonrise"":""15:32"",""moonset"":""06:32"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 96%""},{""gmt"":1455994800,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":96,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 96%, mid-level clouds 86%, high-level clouds 82%)"",""decimal"":""Mostly cloudy\n(low-level clouds 10\/10, mid-level clouds 9\/10, high-level clouds 8\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 8 oktas, mid-level clouds 7 oktas, high-level clouds 7 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.30000300003,""inches"":0.1180011800118},""fraction"":-1},""precipitation"":{""mm"":0.30000300003,""inches"":0},""precipitation_hint"":{""mm"":""snow (0.3 mm \/ 6 hours)"",""inches"":""snow (0.01 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-9,""f"":16},""feel_temperature"":{""c"":-13,""f"":9},""humidity"":78,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":758,""inhg"":29,""mbar"":1010,""hpa"":1010},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":2,""kmh"":7,""mph"":4,""knots"":4,""bft"":2},""wind_gusts"":{""ms"":5,""kmh"":18,""mph"":11,""knots"":10,""bft"":3},""wind_velocity_hint"":""Light breeze"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1455955336,""sunset"":1455991320,""moonrise"":""15:32"",""moonset"":""06:32"",""moon_phase"":3,""moon_phase_hint"":""Waxing gibbous moon, it will be lit at midnight 96%""}],[{""gmt"":1456016400,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":91,""decimal"":9,""oktas"":7},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 88%, mid-level clouds 91%, high-level clouds 66%)"",""decimal"":""Mostly cloudy\n(low-level clouds 9\/10, mid-level clouds 9\/10, high-level clouds 7\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 7 oktas, mid-level clouds 7 oktas, high-level clouds 5 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.10000100001,""inches"":0.0390003900039},""fraction"":-1},""precipitation"":{""mm"":0.10000100001,""inches"":0},""precipitation_hint"":{""mm"":""mainly without precipitation (0.1 mm \/ 6 hours)"",""inches"":""mainly without precipitation (0 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-10,""f"":14},""feel_temperature"":{""c"":-12,""f"":10},""humidity"":78,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":760,""inhg"":29,""mbar"":1013,""hpa"":1013},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":366,""wind_direction_hint"":""Wind blowing from the north-west"",""sunrise"":1455955336,""sunset"":1455991320,""moonrise"":""16:39"",""moonset"":""07:06"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456038000,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":93,""decimal"":9,""oktas"":7},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 93%, mid-level clouds 79%, high-level clouds 42%)"",""decimal"":""Mostly cloudy\n(low-level clouds 9\/10, mid-level clouds 8\/10, high-level clouds 4\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 7 oktas, mid-level clouds 6 oktas, high-level clouds 3 oktas)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.20000200002,""inches"":0.0790007900079},""fraction"":-1},""precipitation"":{""mm"":0.20000200002,""inches"":0},""precipitation_hint"":{""mm"":""snow (0.2 mm \/ 6 hours)"",""inches"":""snow (0.01 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-12,""f"":10},""feel_temperature"":{""c"":-14,""f"":7},""humidity"":83,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":762,""inhg"":30,""mbar"":1015,""hpa"":1015},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1456041592,""sunset"":1456077850,""moonrise"":""16:39"",""moonset"":""07:06"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456059600,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":100,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Overcast\n(low-level clouds 100%, mid-level clouds 68%, high-level clouds 2%)"",""decimal"":""Overcast\n(low-level clouds 10\/10, mid-level clouds 7\/10, high-level clouds 1\/10)"",""oktas"":""Overcast\n(low-level clouds 8 oktas, mid-level clouds 5 oktas, high-level clouds 1 okta)""},""phenomenon"":{""code"":1,""count"":{""mm"":0.10000100001,""inches"":0.0390003900039},""fraction"":-1},""precipitation"":{""mm"":0.10000100001,""inches"":0},""precipitation_hint"":{""mm"":""mainly without precipitation (0.1 mm \/ 6 hours)"",""inches"":""mainly without precipitation (0 inches \/ 6 hours)""},""precipitation_type"":3,""temperature"":{""c"":-9,""f"":16},""feel_temperature"":{""c"":-9,""f"":16},""humidity"":72,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":763,""inhg"":30,""mbar"":1017,""hpa"":1017},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_gusts"":{""ms"":3,""kmh"":11,""mph"":7,""knots"":6,""bft"":2},""wind_velocity_hint"":""Calm"",""wind_direction"":400,""wind_direction_hint"":"""",""sunrise"":1456041592,""sunset"":1456077850,""moonrise"":""16:39"",""moonset"":""07:06"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456081200,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":87,""decimal"":9,""oktas"":7},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(low-level clouds 87%, mid-level clouds 40%)"",""decimal"":""Mostly cloudy\n(low-level clouds 9\/10, mid-level clouds 4\/10)"",""oktas"":""Mostly cloudy\n(low-level clouds 7 oktas, mid-level clouds 3 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-11,""f"":12},""feel_temperature"":{""c"":-13,""f"":9},""humidity"":82,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":765,""inhg"":30,""mbar"":1019,""hpa"":1019},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":361,""wind_direction_hint"":""Wind blowing from the east"",""sunrise"":1456041592,""sunset"":1456077850,""moonrise"":""16:39"",""moonset"":""07:06"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""}],[{""gmt"":1456102800,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":15,""decimal"":2,""oktas"":1},""cloud_cover_hint"":{""pct"":""Mostly clear\n(low-level clouds 15%, mid-level clouds 4%)"",""decimal"":""Mostly clear\n(low-level clouds 2\/10, mid-level clouds 1\/10)"",""oktas"":""Mostly clear\n(low-level clouds 1 okta, mid-level clouds 1 okta)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-16,""f"":3},""feel_temperature"":{""c"":-19,""f"":-2},""humidity"":87,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":767,""inhg"":30,""mbar"":1022,""hpa"":1022},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":359,""wind_direction_hint"":""Wind blowing from the north"",""sunrise"":1456041592,""sunset"":1456077850,""moonrise"":""17:48"",""moonset"":""07:33"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 100%""},{""gmt"":1456124400,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":24,""decimal"":2,""oktas"":2},""cloud_cover_hint"":{""pct"":""Clear with cloudy periods\n(clouds with vertical development 1%, low-level clouds 24%)"",""decimal"":""Clear with cloudy periods\n(clouds with vertical development 1\/10, low-level clouds 2\/10)"",""oktas"":""Clear with cloudy periods\n(clouds with vertical development 1 okta, low-level clouds 2 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":0},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-19,""f"":-2},""feel_temperature"":{""c"":-22,""f"":-8},""humidity"":86,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":768,""inhg"":30,""mbar"":1023,""hpa"":1023},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1456127848,""sunset"":1456164381,""moonrise"":""17:48"",""moonset"":""07:33"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 100%""},{""gmt"":1456146000,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":0,""decimal"":0,""oktas"":0},""cloud_cover_hint"":{""pct"":""Clear\n(no clouds)"",""decimal"":""Clear\n(no clouds)"",""oktas"":""Clear\n(no clouds)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-14,""f"":7},""feel_temperature"":{""c"":-17,""f"":1},""humidity"":80,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":768,""inhg"":30,""mbar"":1023,""hpa"":1023},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":361,""wind_direction_hint"":""Wind blowing from the east"",""sunrise"":1456127848,""sunset"":1456164381,""moonrise"":""17:48"",""moonset"":""07:33"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 100%""},{""gmt"":1456167600,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":0,""decimal"":0,""oktas"":0},""cloud_cover_hint"":{""pct"":""Mostly clear\n(low-level clouds 1%)"",""decimal"":""Mostly clear\n(low-level clouds 1\/10)"",""oktas"":""Mostly clear\n(low-level clouds 1 okta)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-14,""f"":7},""feel_temperature"":{""c"":-14,""f"":7},""humidity"":79,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":769,""inhg"":30,""mbar"":1025,""hpa"":1025},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Calm"",""wind_direction"":400,""wind_direction_hint"":""Wind blowing from the north-east"",""sunrise"":1456127848,""sunset"":1456164381,""moonrise"":""17:48"",""moonset"":""07:33"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 100%""}],[{""gmt"":1456189200,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":15,""decimal"":2,""oktas"":1},""cloud_cover_hint"":{""pct"":""Mostly clear\n(low-level clouds 15%)"",""decimal"":""Mostly clear\n(low-level clouds 2\/10)"",""oktas"":""Mostly clear\n(low-level clouds 1 okta)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-19,""f"":-2},""feel_temperature"":{""c"":-22,""f"":-8},""humidity"":87,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":771,""inhg"":30,""mbar"":1027,""hpa"":1027},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":359,""wind_direction_hint"":""Wind blowing from the north"",""sunrise"":1456127848,""sunset"":1456164381,""moonrise"":""18:56"",""moonset"":""07:57"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456210800,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":15,""decimal"":2,""oktas"":1},""cloud_cover_hint"":{""pct"":""Mostly clear\n(low-level clouds 15%, high-level clouds 3%)"",""decimal"":""Mostly clear\n(low-level clouds 2\/10, high-level clouds 1\/10)"",""oktas"":""Mostly clear\n(low-level clouds 1 okta, high-level clouds 1 okta)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-22,""f"":-8},""feel_temperature"":{""c"":-26,""f"":-15},""humidity"":86,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":772,""inhg"":30,""mbar"":1029,""hpa"":1029},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":365,""wind_direction_hint"":""Wind blowing from the west"",""sunrise"":1456214102,""sunset"":1456250910,""moonrise"":""18:56"",""moonset"":""07:57"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456232400,""gmt_string"":""13:00"",""cloud_cover"":{""pct"":74,""decimal"":7,""oktas"":6},""cloud_cover_hint"":{""pct"":""Cloudy\n(mid-level clouds 74%, high-level clouds 87%)"",""decimal"":""Cloudy\n(mid-level clouds 7\/10, high-level clouds 9\/10)"",""oktas"":""Cloudy\n(mid-level clouds 6 oktas, high-level clouds 7 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-15,""f"":5},""feel_temperature"":{""c"":-18,""f"":0},""humidity"":80,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":771,""inhg"":30,""mbar"":1027,""hpa"":1027},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":361,""wind_direction_hint"":""Wind blowing from the east"",""sunrise"":1456214102,""sunset"":1456250910,""moonrise"":""18:56"",""moonset"":""07:57"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""},{""gmt"":1456254000,""gmt_string"":""19:00"",""cloud_cover"":{""pct"":96,""decimal"":10,""oktas"":8},""cloud_cover_hint"":{""pct"":""Mostly cloudy\n(mid-level clouds 96%, high-level clouds 95%)"",""decimal"":""Mostly cloudy\n(mid-level clouds 10\/10, high-level clouds 10\/10)"",""oktas"":""Mostly cloudy\n(mid-level clouds 8 oktas, high-level clouds 8 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-13,""f"":9},""feel_temperature"":{""c"":-13,""f"":9},""humidity"":84,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":771,""inhg"":30,""mbar"":1027,""hpa"":1027},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Calm"",""wind_direction"":400,""wind_direction_hint"":""Wind blowing from the south-east"",""sunrise"":1456214102,""sunset"":1456250910,""moonrise"":""18:56"",""moonset"":""07:57"",""moon_phase"":4,""moon_phase_hint"":""Full moon, it will be lit at midnight 99%""}],[{""gmt"":1456275600,""gmt_string"":""01:00"",""cloud_cover"":{""pct"":75,""decimal"":8,""oktas"":6},""cloud_cover_hint"":{""pct"":""Cloudy\n(low-level clouds 75%, mid-level clouds 70%)"",""decimal"":""Cloudy\n(low-level clouds 8\/10, mid-level clouds 7\/10)"",""oktas"":""Cloudy\n(low-level clouds 6 oktas, mid-level clouds 6 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-16,""f"":3},""feel_temperature"":{""c"":-19,""f"":-2},""humidity"":85,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":770,""inhg"":30,""mbar"":1026,""hpa"":1026},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":359,""wind_direction_hint"":""Wind blowing from the north"",""sunrise"":1456214102,""sunset"":1456250910,""moonrise"":""20:04"",""moonset"":""08:18"",""moon_phase"":5,""moon_phase_hint"":""Waning gibbous moon, it will be lit at midnight 96%""},{""gmt"":1456297200,""gmt_string"":""07:00"",""cloud_cover"":{""pct"":35,""decimal"":4,""oktas"":3},""cloud_cover_hint"":{""pct"":""Variable clouds\n(mid-level clouds 35%)"",""decimal"":""Variable clouds\n(mid-level clouds 4\/10)"",""oktas"":""Variable clouds\n(mid-level clouds 3 oktas)""},""phenomenon"":{""code"":0,""count"":{""mm"":0,""inches"":0},""fraction"":-1},""precipitation"":{""mm"":0,""inches"":0},""precipitation_hint"":{""mm"":""without precipitation"",""inches"":""without precipitation""},""precipitation_type"":0,""temperature"":{""c"":-21,""f"":-6},""feel_temperature"":{""c"":-25,""f"":-13},""humidity"":86,""humidity_hint"":""High humidity"",""pressure"":{""mmhg"":768,""inhg"":30,""mbar"":1023,""hpa"":1023},""pressure_hint"":""Very high air pressure"",""wind_velocity"":{""ms"":1,""kmh"":4,""mph"":2,""knots"":2,""bft"":1},""wind_gusts"":{""ms"":0,""kmh"":0,""mph"":0,""knots"":0,""bft"":0},""wind_velocity_hint"":""Light air"",""wind_direction"":363,""wind_direction_hint"":""Wind blowing from the south"",""sunrise"":1456300356,""sunset"":1456337440,""moonrise"":""20:04"",""moonset"":""08:18"",""moon_phase"":5,""moon_phase_hint"":""Waning gibbous moon, it will be lit at midnight 96%""}]]},""backgrounds"":{""day"":[""backgrounds\/day\/1_1.jpg"",""backgrounds\/day\/2_1.jpg"",""backgrounds\/day\/3_1.jpg"",""backgrounds\/day\/4_1.jpg"",""backgrounds\/day\/5_1.jpg""],""night"":[""backgrounds\/night\/1_2.jpg"",""backgrounds\/night\/2_2.jpg"",""backgrounds\/night\/3_2.jpg"",""backgrounds\/night\/4_2.jpg"",""backgrounds\/night\/5_2.jpg""],""update"":300}}}";

        private const string ResultRu = @"";

        #endregion

        #region Methods

        public Task<IList<WeatherForecastProjection>> GetForecastByCityIdAsync(int idCity)
        {
            var deserializeObject = JsonConvert.DeserializeObject<Rp5WeatherForecastRootObject>(ResultEn);

            var result = ModelExtensions.ConvertToWeatherForecastProjections(deserializeObject);

            return Task.FromResult<IList<WeatherForecastProjection>>(result);
        }

        #endregion

    }
}