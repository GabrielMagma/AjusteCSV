using AjusteCSV.BL.DTOs;
using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace AjusteCSV.BL.Services
{
    public class FileServices : IFileServices
    {
        private readonly IFileDataAccess fileDataAccess;
        public FileServices(IFileDataAccess _fileDataAccess)
        {
            fileDataAccess = _fileDataAccess;
        }
        public ResponseQuery<string> CreateFileCSV(string name, ResponseQuery<string> response)
        {
            try
            {   
                
                List<IdeamDTO> ideamList = new List<IdeamDTO>();
                string[] fileLines = File.ReadAllLines($"./files/{name}.csv");
                List<Register> valueFinal = new List<Register>();
                Register register = new Register();
                string routeFile = $".\\files\\{name}{DateTime.Now.ToString("yyyy-MM-dd")}.csv";
                TextWriter newFile = new StreamWriter(routeFile);
                newFile.Close();
                using (var writer = new StreamWriter(new FileStream(routeFile, FileMode.Open), Encoding.UTF8))
                {
                    using (var csvWriter = new CsvWriter(writer, CultureInfo.CurrentCulture))
                    {

                        foreach (var item in fileLines.Skip(1))
                        {
                            IdeamDTO ideam = new IdeamDTO();
                            var valueLines = item.Split(",");

                            ideam.Id = 0;

                            register.CodigoEstacion = int.Parse(valueLines[0]);
                            ideam.Stationcode = valueLines[0];

                            register.NombreEstacion = valueLines[1];
                            ideam.Stationname = valueLines[1];

                            register.Latitud = valueLines[2];
                            ideam.Latitude = Double.Parse(valueLines[2]);

                            register.Longitud = valueLines[3];
                            ideam.Longitude = Double.Parse(valueLines[3]);

                            register.Altitud = int.Parse(valueLines[4]);
                            ideam.Altitude = Double.Parse(valueLines[4]);

                            register.Departamento = valueLines[8];
                            ideam.Department = valueLines[8];

                            register.Municipio = valueLines[9];
                            ideam.Municipality = valueLines[9];

                            register.IdParametro = valueLines[12];
                            ideam.Parameterid = valueLines[12];

                            register.Frecuencia = valueLines[15];
                            ideam.Frequency = valueLines[15];

                            var date = valueLines[16].Split(" ");
                            var dateSplited = date[0].Split('-', '/');
                            var dateTemp = (dateSplited[2] + "/" + dateSplited[1] + "/" + dateSplited[0]);
                            register.Fecha = dateTemp;
                            ideam.Date = DateOnly.Parse(dateTemp);

                            register.Valor = double.Parse(valueLines[17]);
                            ideam.Precipitation = double.Parse(valueLines[18]);

                            valueFinal.Add(register);
                            ideamList.Add(ideam);
                            

                            register = new Register();
                        }
                        csvWriter.WriteRecords(valueFinal);
                        fileDataAccess.CreateFile(ideamList);
                    }

                }

                response.Message = "File created on the project root ./files";
                response.Success = true;
                return response;

            }
            catch (Exception ex)
            {                
                response.Message = ex.Message;
                response.Success = false;
            }            
            return response;
        }

        //private DateTime ParseDate(string dateString)
        //{
        //    foreach (var format in _timeFormats)
        //    {
        //        if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        //        {
        //            return parsedDate;
        //        }
        //    }
        //    throw new FormatException($"El formato de fecha {dateString} no es válido.");
        //}

    }
}
