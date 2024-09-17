using AjusteCSV.BL.Interfaces;
using AjusteCSV.BL.Responses;
using CsvHelper;
using LecturaCSV;
using System.Globalization;
using System.Text;

namespace AjusteCSV.BL.Services
{
    public class FileServices : IFileServices
    {
        public ResponseQuery<string> CreateFileCSV(string name, ResponseQuery<string> response)
        {
            try
            {                               
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
                            var valueLines = item.Split(",");
                            register.CodigoEstacion = int.Parse(valueLines[0]);
                            register.NombreEstacion = valueLines[1];
                            register.Latitud = valueLines[2];
                            register.Longitud = valueLines[3];
                            register.Altitud = int.Parse(valueLines[4]);
                            register.Departamento = valueLines[8];
                            register.Municipio = valueLines[9];
                            register.IdParametro = valueLines[12];
                            register.Frecuencia = valueLines[15];
                            var date = valueLines[16].Split(" ");
                            var dateSplited = date[0].Split('-', '/');
                            register.Fecha = (dateSplited[2] + "/" + dateSplited[1] + "/" + dateSplited[0]);
                            register.Valor = double.Parse(valueLines[17]);

                            valueFinal.Add(register);

                            register = new Register();
                        }
                        csvWriter.WriteRecords(valueFinal);
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
    }
}
