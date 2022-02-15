using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RowsInFieldMethod.Models
{
   public class Point
    {
      public double Longitude { get; set; }

        public double Latitude { get; set; }

        public Point()
        {

        }
        public Point(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }


        //POI, Need more elgant way of reading polygon in, maybe CSV file?

       public static List<Point> FarmPolygon = new List<Point>()
         {
             new Point{
             Latitude =44.980208845897117,
             Longitude =20.359723426144189 },

               new Point{
             Latitude = 44.980140833322089,
             Longitude =20.359747013450932},

               new Point{
             Latitude = 44.9800897154898,
             Longitude = 20.3597975553616},

                new Point{
             Latitude =44.979846901103933,
             Longitude = 20.360113158170968},

                   new Point{
             Latitude = 44.979561968002606,
             Longitude = 20.360575465962384},

                    new Point{
             Latitude = 44.979282785293513,
             Longitude = 20.360923555402596},

                      new Point{
             Latitude = 44.978844734250458,
             Longitude = 20.361371319809805},

                      new Point{
             Latitude = 44.978575665259314,
             Longitude = 20.361628857833594},

                      new Point{
             Latitude = 44.978524535221126,
             Longitude = 20.361677367512026},

                         new Point{
             Latitude = 44.978524535221126,
             Longitude = 20.361677367512026},

                          new Point{
             Latitude = 44.978346395891506,
             Longitude = 20.3613087434552},

                          new Point{
             Latitude = 44.978200339841614,
             Longitude = 20.361011171039049},

                           new Point{
             Latitude = 44.978064375529669,
             Longitude = 20.360747605399375},

                            new Point{
             Latitude = 44.977849401739867,
             Longitude = 20.360955458745192},

                            new Point{
             Latitude = 44.97762401856231,
             Longitude = 20.361169260274824},

                            new Point{
             Latitude = 44.977288713291792,
             Longitude = 20.361510474940054},

                             new Point{
             Latitude = 44.97708949971824,
             Longitude = 20.361703689317736},

                              new Point{
             Latitude = 44.977028322075817,
             Longitude = 20.3617422896955},

                                new Point{
             Latitude =  44.976965049293142,
             Longitude =20.3617442599121},

                                 new Point{
             Latitude =  44.976908776339464,
             Longitude = 20.361726240477843},

                                 new Point{
             Latitude =  44.976864071238978,
             Longitude = 20.361684122272223},

                                 new Point{
             Latitude =  44.976815880332921,
             Longitude = 20.361598160400654},

                                  new Point{
             Latitude =  44.976741702012035,
             Longitude = 20.361420663887856 },

                                    new Point{
             Latitude =  44.976699918743471,
             Longitude = 20.361289353867058 },

                                     new Point{
             Latitude =  44.9766769894046,
             Longitude =  20.3611651906785 },

                                      new Point{
             Latitude =  44.976668616559131,
             Longitude =  20.361020193053079 },

                                      new Point{
             Latitude =  44.976666421336262,
             Longitude =  20.360804864443327 },

                                new Point{
             Latitude =  44.976641162315346,
             Longitude =  20.36066664956828 },

                                new Point{
             Latitude =  44.976606980006679,
             Longitude =  20.360558592066489 },

                                new Point{
             Latitude =  44.976460171147536,
             Longitude =  20.360239478286086 },

                                new Point{
             Latitude =  44.976253314070433,
             Longitude =  20.35982325092543 },

                                new Point{
             Latitude =  44.976163634534856,
             Longitude =  20.359659120894573 },

                                new Point{
             Latitude =  44.976036878310794,
             Longitude =  20.359464965877997 },

                                 new Point{
             Latitude =  44.975855264091038,
             Longitude =  20.359168186551347},

                                 new Point{
             Latitude =  44.975675408397308 ,
             Longitude =  20.358848053649776 },

                                  new Point{
             Latitude =  44.975624372661265 ,
             Longitude =  20.35876884935719 },

                                    new Point{
             Latitude =  44.975572195315472 ,
             Longitude =  20.3587268176619789 },

                                      new Point{
             Latitude =  44.975513618557457 ,
             Longitude =  20.358715422172878 },

                                       new Point{
             Latitude =  44.975466845453418 ,
             Longitude =  20.358722031088028 },

                                         new Point{
             Latitude =  44.975421233404674 ,
             Longitude =  20.358759064977743 },

                                         new Point{
             Latitude =  44.975360359351569 ,
             Longitude =  20.358851564401686 },

                                         new Point{
             Latitude =  44.975315559683025 ,
             Longitude =  20.358953142717329 },

                                           new Point{
             Latitude =  44.975216379423692 ,
             Longitude =  20.359117343719369 },

                                           new Point{
             Latitude =  44.975069264819496 ,
             Longitude =  20.359321900652326 },

                                            new Point{
             Latitude =  44.975001785457479 ,
             Longitude =  20.359424491528543 },

                             new Point{
             Latitude =  44.974923098650059 ,
             Longitude =  20.359551176578449 },

                             new Point{
             Latitude =  44.974809997181026 ,
             Longitude =  20.35975332369674 },

                              new Point{
             Latitude =  44.97473693254981 ,
             Longitude =  20.359871321346692 },

                              new Point{
             Latitude =  44.974656666887043 ,
             Longitude =  20.359957312574629 },

                              new Point{
             Latitude =  44.974536430180564 ,
             Longitude =  20.360058966863861 },

                               new Point{
             Latitude =  44.975035822350762 ,
             Longitude =  20.361097426378404 },

                               new Point{
             Latitude =  44.975379200779223 ,
             Longitude =  20.361845810089847 },

                               new Point{
             Latitude =  44.975686480224006 ,
             Longitude =  20.36257874947465 },

                               new Point{
             Latitude =  44.975956082808729 ,
             Longitude =  20.363223081845128 },

                                new Point{
             Latitude =  44.976188324287058 ,
             Longitude =  20.363802898216967 },

                                 new Point{
             Latitude =  44.976420947264813 ,
             Longitude =  20.364370920143639 },

                                 new Point{
             Latitude =  44.97685069713193 ,
             Longitude =  20.365357585524041 },

                                 new Point{
             Latitude =  44.977384851946915 ,
             Longitude =  20.366569759162719 },

                                 new Point{
             Latitude =  44.977928913077136 ,
             Longitude =  20.367785017150805 },

                                  new Point{
             Latitude =  44.978718401731157 ,
             Longitude =  20.369514065904543 },

                                  new Point{
             Latitude =  44.979418321621004 ,
             Longitude =  20.371035499832036 },

                                   new Point{
             Latitude =  44.979922226785526 ,
             Longitude =  20.372110748241909 },

                                    new Point{
             Latitude =  44.980561167085817 ,
             Longitude =  20.373549831824185 },

                                    new Point{
             Latitude =  44.980765150933138 ,
             Longitude =  20.3739437207599 },

                                     new Point{
             Latitude =  44.980887138437467 ,
             Longitude =  20.373863627528856 },

                                      new Point{
             Latitude =  44.981142045348335 ,
             Longitude =  20.373628613844357 },

                                       new Point{
             Latitude =  44.981483937244491 ,
             Longitude =  20.373267207696454 },

                                         new Point{
             Latitude =  44.981583141127963 ,
             Longitude =  20.373169222403309 },

                                         new Point{
             Latitude =  44.981785767214078 ,
             Longitude =  20.373052986375047 },

                                         new Point{
             Latitude =  44.982058814835725 ,
             Longitude =  20.37281041090932 },

                                         new Point{
             Latitude =  44.98239791813851 ,
             Longitude =  20.372498999490478 },

                                         new Point{
             Latitude =  44.982754229420912 ,
             Longitude =  20.37215758895951 },

                                         new Point{
             Latitude =  44.983144195887071 ,
             Longitude =  20.371748707353326 },

                                          new Point{
             Latitude =  44.983182454679387 ,
             Longitude =  20.371683346477003 },

                                           new Point{
             Latitude =  44.983159824922772 ,
             Longitude =  20.371333510421437 },

                                            new Point{
             Latitude =  44.983054089886323 ,
             Longitude =  20.370604946758434 },

                                            new Point{
             Latitude =  44.982859450370533 ,
             Longitude =  20.369443182626018 },

                                            new Point{
             Latitude =  44.982739455020912 ,
             Longitude =  20.368758923350409 },

                                            new Point{
             Latitude =  44.982562077798711 ,
             Longitude =  20.367726739793074 },

                                             new Point{
             Latitude =  44.982383227841936 ,
             Longitude =  20.366690393089474 },

                                             new Point{
             Latitude =  44.982239130495259 ,
             Longitude =  20.365851159032694 },

                                             new Point{
             Latitude =  44.982107049219366 ,
             Longitude =  20.365085617083455 },

                                              new Point{
             Latitude =  44.982020445380371 ,
             Longitude =  20.364566785764676 },

                           new Point{
             Latitude =  44.981853150287748 ,
             Longitude =  20.363622162123757 },

                             new Point{
             Latitude =  44.981706440013284 ,
             Longitude =  20.36277041540238 },

                                  new Point{
             Latitude =  44.981564579924587 ,
             Longitude =  20.361901749735686 },

                        new Point{
             Latitude =  44.981538792726219 ,
             Longitude =  20.361749322617523 },

                        new Point{
             Latitude =  44.9814960898648 ,
             Longitude =  20.36164667705949 },

                         new Point{
             Latitude =  44.981444427233583 ,
             Longitude =  20.361503289270431 },

                         new Point{
             Latitude =  44.98120108935813 ,
             Longitude =  20.361098207869169 },

                         new Point{
             Latitude =  44.980691375105188 ,
             Longitude =  20.360354266397078 },

                         new Point{
             Latitude =  44.980265126811808 ,
             Longitude =  20.359774929066315 },

                         new Point{
             Latitude =  44.980208845897117 ,
             Longitude =  20.359723426144189 }
         };
    }


}
