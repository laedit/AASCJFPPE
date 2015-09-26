using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AASCJFPPE.DAL.Datas;
using System.Data.SqlServerCe;
using System.IO;

namespace AASCJFPPE.DAL
{
    /// <summary>
    /// Class used for database maintenance
    /// </summary>
    public static class DatabaseMaintenance
    {
        #region Public methods

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public static void CloseConnection()
        {
            EntityBase.Connection.Dispose();
            EntityBase.Connection = null;
        }

        /// <summary>
        /// Updates the database.
        /// </summary>
        /// <returns></returns>
        public static Boolean UpdateDatabase()
        {
            Boolean flag = true;

            String lastversion = DataRepository.Instance.Version.GetMaxNumero();

            // Version 0.0.2
            if (lastversion == "0.0.1")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_2();
                lastversion = "0.0.2";
            }

            // Version 0.0.3
            if (flag && lastversion == "0.0.2")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_3();
                lastversion = "0.0.3";
            }

            // Version 0.0.4
            if (flag && lastversion == "0.0.3")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_4();
                lastversion = "0.0.4";
            }

            // Version 0.0.5
            if (flag && lastversion == "0.0.4")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_5();
                lastversion = "0.0.5";
            }

            // Version 0.0.6
            if (flag && lastversion == "0.0.5")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_6();
                lastversion = "0.0.6";
            }

            // Version 0.0.7
            if (flag && lastversion == "0.0.6")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_7();
                lastversion = "0.0.7";
            }

            // Version 0.0.8
            if (flag && lastversion == "0.0.7")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_8();
                lastversion = "0.0.8";
            }

            // Version 0.0.9
            if (flag && lastversion == "0.0.8")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_0_9();
                lastversion = "0.0.9";
            }

            // Version 0.1.0
            if (flag && lastversion == "0.0.9")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_1_0();
                lastversion = "0.1.0";
            }

            // Version 0.1.1
            if (flag && lastversion == "0.1.0")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_1_1();
                lastversion = "0.1.1";
            }

            // Version 0.1.2
            if (flag && lastversion == "0.1.1")
            {
                BackUpDatabase();
                flag = UpdateDatabaseVersion0_1_2();
                lastversion = "0.1.2";
            }

            return flag;
        }

        /// <summary>
        /// Backs up database.
        /// </summary>
        public static void BackUpDatabase()
        {
            String databasePath = EntityBase.ConnectionString.Split(';')[0].Split('=')[1];

            String dataFolderName = Path.GetDirectoryName(databasePath) + "/";
            String dateTimePrefix = DateTime.Now.ToString("yyyyMMdd_HHmmss_");
            String outputFileName = dateTimePrefix + "datas.sdf";

            if (File.Exists(dataFolderName + outputFileName))
            {
                List<String> files = Directory.GetFiles(dataFolderName, dateTimePrefix + "*").ToList();
                if (files.Count == 1)
                {
                    outputFileName = dateTimePrefix + "1_datas.sdf";
                }
                else
                {
                    files = files.OrderByDescending(f => f).ToList();
                    files.RemoveAt(0);

                    String lastBackUp = files.First().Replace("_datas.sdf", String.Empty);

                    if (lastBackUp[lastBackUp.Length - 2] == '_')
                    {
                        Int32 lastNumber = -1;
                        Int32.TryParse(lastBackUp[lastBackUp.Length - 1].ToString(), out lastNumber);

                        lastNumber++;
                        outputFileName = dateTimePrefix + lastNumber + "_datas.sdf";
                    }
                }
            }

            File.Copy(databasePath, dataFolderName + outputFileName);
        }

        #endregion Public methods


        #region  Update Database Version

        /// <summary>
        /// Updates the database version0_0_2.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_2()
        {
            Boolean flag = false;

            try
            {
                DataRepository.Instance.DomaineActivite.Create(
                    new List<DomaineActivite>()
                    {
                        new DomaineActivite(){ Discipline=1, Intitule = "Conjugaison"},
                        new DomaineActivite(){ Discipline=2, Intitule = "Problèmes"}
                    });

                DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = "0.0.2" });

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        }

        /// <summary>
        /// Updates the database version0_0_3.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_3()
        {
            Boolean flag = false;

            try
            {
                Discipline mathematiques = DataRepository.Instance.Discipline.SelectById(2).First();
                mathematiques.Intitule += "s";

                DataRepository.Instance.Discipline.Update(mathematiques);

                DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = "0.0.3" });

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        }


        /// <summary>
        /// Updates the database version0_0_4.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_4()
        {
            Boolean flag = false;

            try
            {
                DataRepository.Instance.DomaineActivite.Create(
                    new List<DomaineActivite>()
                    {
                        new DomaineActivite(){ Discipline=1, Intitule = "Musique"}
                    });

                DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = "0.0.4" });

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        }

        /// <summary>
        /// Updates the database version0_0_5.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_5()
        {
            Boolean flag = false;

            try
            {
                Discipline sciences = DataRepository.Instance.Discipline.SelectByIntitule("Sciences Expérimentales et Technologie").First();
                sciences.Intitule = "Sciences";

                DataRepository.Instance.Discipline.Update(sciences);

                DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = "0.0.5" });

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        }

        /// <summary>
        /// Updates the database version0_0_6.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_6()
        {
            Boolean flag = false;

            try
            {
                DataRepository.Instance.Discipline.Create("Arts plastiques");

                DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = "0.0.6" });

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        } // end function UpdateDatabaseVersion0_0_6

        /// <summary>
        /// Updates the database version0_0_7.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_7()
        {
            // Not used before because of the database structure changes
            return UpdateDatabaseGeneric(() =>
            {
                try
                {
                    DataRepository.ExecuteNonQuery("ALTER TABLE Version ADD Description nvarchar(1000)");
                }
                // In case the column already exists
                catch { }

                AddDescriptionToVersion("0.0.1", "Création de la base de données.");
                AddDescriptionToVersion("0.0.2", "Ajout des Domaines D'activités \"Conjugaison\" et \"Problèmes\" respectivement pour les Disciplines \"Français\" et \"Mathématiques\".");
                AddDescriptionToVersion("0.0.3", "Ajout du 's' manquant pour la Discipline \"Mathématiques\".");
                AddDescriptionToVersion("0.0.4", "Ajout du Domain d'Activité \"Musique\" pour la Discipline \"Français\".");
                AddDescriptionToVersion("0.0.5", "La Discipline \"Sciences Expérimentales et Technologie\" devient \"Sciences\".");
                AddDescriptionToVersion("0.0.6", "Ajout de la Discipline \"Arts plastiques\".");
            },
            "0.0.7",
            "Ajout de la colonne [Version].[Description]. Ajout des données de cette colonne.");
        } // end function UpdateDatabaseVersion0_0_7

        /// <summary>
        /// Updates the database version0_0_8.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_8()
        {
            return UpdateDatabaseGeneric(() =>
            {
                // TODO vérifier que la contrainte existe avant de la drop
                DataRepository.ExecuteNonQuery("ALTER TABLE InformationComplementaire DROP CONSTRAINT PK_InformationComplementaire;");

                DataRepository.ExecuteNonQuery("ALTER TABLE InformationComplementaire DROP Column Id;");
            },
            "0.0.8",
            "Suppression de la colonne [InformationComplementaire].[Id].");
        } // end function UpdateDatabaseVersion0_0_8

        /// <summary>
        /// Updates the database version0_0_9.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_0_9()
        {
            return UpdateDatabaseGeneric(() =>
            {
                DataRepository.ExecuteNonQuery("sp_rename 'ListeEleve', 'Eleve';");

                DataRepository.ExecuteNonQuery("ALTER TABLE Eleve ADD COLUMN Informations nvarchar(4000);");
            },
            "0.0.9",
            "Changement de nom de [ListeEleve] à [Eleve]. Ajout de la colone [Eleve].[Informations]");
        } // end function UpdateDatabaseVersion0_0_9

        /// <summary>
        /// Updates the database version0_1_0.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_1_0()
        {
            return UpdateDatabaseGeneric(() =>
            {
                // Structure
                DataRepository.ExecuteNonQuery("ALTER TABLE DidactiqueFP ADD Ordre int;");
                DataRepository.ExecuteNonQuery("CREATE TABLE Conditions" +
                                                "(" +
                                                " Id bigint IDENTITY(0,1) PRIMARY KEY," +
                                                " Intitule nvarchar(100) NOT NULL" +
                                                ");");


                DataRepository.ExecuteNonQuery("ALTER TABLE DidactiqueFP DROP COLUMN Conditions;");
                DataRepository.ExecuteNonQuery("ALTER TABLE DidactiqueFP ADD Conditions bigint CONSTRAINT FK_Conditions_DidactiqueFP REFERENCES Conditions (Id) ON DELETE CASCADE ON UPDATE CASCADE;");

                DataRepository.ExecuteNonQuery("ALTER TABLE FichePreparatoire ADD COLUMN BilanPositif nvarchar(4000);");
                DataRepository.ExecuteNonQuery("ALTER TABLE FichePreparatoire ADD COLUMN BilanNegatif nvarchar(4000);");
                
                // Données
                DataRepository.Instance.Conditions.Create("Introduction / Mise en projet");
                DataRepository.Instance.Conditions.Create("Recherche");
                DataRepository.Instance.Conditions.Create("Mise en commun");
                DataRepository.Instance.Conditions.Create("Structuration");
                DataRepository.Instance.Conditions.Create("Différenciation");
                DataRepository.Instance.Conditions.Create("Institutionnalisation");

            },
            "0.1.0",
            "Modifications effectuées afin de gérer les fiches préparatoires.");
        } // end function UpdateDatabaseVersion0_1_0

        /// <summary>
        /// Updates the database version0_1_1.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_1_1()
        {
            return UpdateDatabaseGeneric(() =>
            {
                // Structure
                DataRepository.ExecuteNonQuery("ALTER TABLE Link_FP_DidactiqueFP DROP COLUMN Ordre;");

            },
            "0.1.1",
            "Suppression de la colonne inutile 'Link_FP_DidactiqueFP'.'Ordre'.");
        } // end function UpdateDatabaseVersion0_1_1

        /// <summary>
        /// Updates the database version0_1_2.
        /// </summary>
        /// <returns></returns>
        private static Boolean UpdateDatabaseVersion0_1_2()
        {
            return UpdateDatabaseGeneric(() =>
            {
                // Données
                DataRepository.Instance.Discipline.Create("Relaxation");
                DataRepository.Instance.Discipline.Create("Education musicale");
                DataRepository.Instance.Discipline.Create("Graphisme");

                DataRepository.Instance.DomaineActivite.Create(DataRepository.Instance.Discipline.SelectByIntitule("E.P.S.").FirstOrDefault().Id, "Education motrice");
            },
            "0.1.2",
            "Ajout des disciplines 'Relaxation', 'Education musicale' et 'Graphisme' ainsi que du domaine d'activité 'Education motrice' pour la matière 'E.P.S.'.");
        } // end function UpdateDatabaseVersion0_1_1

        #endregion Update Database Version


        #region Utilities

        /// <summary>
        /// Updates the database generic.
        /// </summary>
        private static Boolean UpdateDatabaseGeneric(Action action, String numero, String description)
        {
            Boolean flag = false;

            try
            {
                action();

                AddDatabaseVersion(numero, description);

                flag = true;
            }
            catch (Exception ex)
            {
                // TODO Temporary solution
                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(DateTime.Now);
                    writer.WriteLine(ex.ToString());
                }
            }

            return flag;
        } // end function UpdateDatabaseGeneric

        /// <summary>
        /// Adds the description to version.
        /// </summary>
        /// <param name="numero">The numero.</param>
        /// <param name="description">The description.</param>
        private static void AddDescriptionToVersion(String numero, String description)
        {
            AASCJFPPE.DAL.Datas.Version v = DataRepository.Instance.Version.SelectByNumero(numero).First();
            v.Description = description;
            DataRepository.Instance.Version.Update(v);
        } // end procedure AddDescriptionToVersion

        /// <summary>
        /// Adds the database version.
        /// </summary>
        /// <param name="numero">The numero.</param>
        /// <param name="description">The description.</param>
        private static void AddDatabaseVersion(String numero, String description)
        {
            DataRepository.Instance.Version.Create(new Datas.Version() { Date = DateTime.Now, Numero = numero, Description = description });
        } // end procedure AddDatabaseVersion

        #endregion Utilities
    }
}
