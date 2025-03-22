using System.Runtime.CompilerServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoHungaro
{
    public partial class Form1 : Form
    {


        int[,] TablaConTachas;//0: no tachas. 1: Una tacha. 2: Dos tachas cruzadas.
        int intFilas = 0;
        int intColumnas = 0;
        int[] FilasCantidadDeCero;
        int[] ColumnasCantidadDeCeros;
        int CantidadDeTachasUtilizadas = 0;

        int[,] MatrizOriginalProblema;
        //bool HayCeros = true;
        public Form1()
        {
            InitializeComponent();
            dtgDatosDelEjercicio.Rows.Clear();
            dtgDatosDelEjercicio.Columns.Clear();
            dtgDatosDelEjercicio.AllowUserToAddRows = false;
            dtgDatosDelEjercicio.AllowUserToDeleteRows = false;
            dtgDatosDelEjercicio.AllowUserToResizeColumns = false;
            dtgDatosDelEjercicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarEjercicioUno();
            //CargarEjercicioDos();
            //CargarEjercicioTres();
        }

        private void ImprimirFilas()
        {
            string strTabla = "Tabla con tachas\n";
            for (int i = 0; i < intFilas; i++)
            {
                strTabla += FilasCantidadDeCero[i].ToString() + " ";

            }
            MessageBox.Show(strTabla);
        }

        private void ImprimirTabla()
        {
            string strTabla = "Tabla con tachas\n";
            for (int i = 0; i < intFilas; i++)
            {
                for (int j = 0; j < intColumnas; j++)
                {
                    strTabla += TablaConTachas[i, j].ToString() + " ";
                }
                strTabla += "\n";
                
            }
            MessageBox.Show(strTabla);
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                intFilas = int.Parse(txtFilas.Text);
                intColumnas = int.Parse(txtColumnas.Text);
                if (intFilas < 1 || intColumnas < 1)
                {
                    throw new Exception("La cantidad de columnas o filas es invalida.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            EnumerarDataGridView();
            ValidarEquilibrioTabla();
        }
        private void GuardarMatrizOriginal()
        {
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    MatrizOriginalProblema[fila, columna] = int.Parse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString());
                }
            }
        }
        private void EnumerarDataGridView()
        {
            dtgDatosDelEjercicio.Rows.Clear();

            for (int i = 1; i <= intColumnas; i++)
            {
                dtgDatosDelEjercicio.Columns.Add("column" + i.ToString(), i.ToString());
            }
            for (int i = 1; i <= intFilas; i++)
            {
                dtgDatosDelEjercicio.Rows.Add();
                dtgDatosDelEjercicio.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }


        private void ValidarEquilibrioTabla()
        {

            if (intFilas > intColumnas)
            {
                intColumnas += 1;
                dtgDatosDelEjercicio.Columns.Add("column", "Fic");
                RellenarDeCerosColumnaFicticia();
            }
            if (intFilas < intColumnas)
            {
                intFilas += 1;
                dtgDatosDelEjercicio.Rows.Add();
                dtgDatosDelEjercicio.Rows[dtgDatosDelEjercicio.RowCount - 1].HeaderCell.Value = "Fic";
                RellenarDeCerosFilaFicticia();
            }
        }

        private void RellenarDeCerosFilaFicticia()
        {
            for (int i = 0; i < dtgDatosDelEjercicio.ColumnCount; i++)
            {
                dtgDatosDelEjercicio.Rows[dtgDatosDelEjercicio.RowCount - 1].Cells[i].Value = 0;
            }
        }
        private void RellenarDeCerosColumnaFicticia()
        {
            for (int i = 0; i < dtgDatosDelEjercicio.RowCount; i++)
            {
                dtgDatosDelEjercicio.Rows[i].Cells[dtgDatosDelEjercicio.ColumnCount - 1].Value = 0;
            }
        }
        private void PrimerPasoRestarEnFilaConElMenor()
        {
            int MenorEncontrado = int.MaxValue;

            for (int j = 0; j < dtgDatosDelEjercicio.RowCount; j++)
            {
                MenorEncontrado = int.MaxValue;

                for (int i = 0; i < dtgDatosDelEjercicio.ColumnCount; i++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[j].Cells[i].Value.ToString(), out value))
                    {
                        if (MenorEncontrado > value)
                        {
                            MenorEncontrado = value;
                        }
                    }
                }
                for (int i = 0; i < dtgDatosDelEjercicio.ColumnCount; i++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[j].Cells[i].Value.ToString(), out value))
                    {
                        dtgDatosDelEjercicio.Rows[j].Cells[i].Value = value - MenorEncontrado;
                    }
                    
                }
            }



        }
        private void SegundoPasoRestarColumnaConElMenor()
        {
            int MenorEncontrado = int.MaxValue;

            for (int i = 0; i < dtgDatosDelEjercicio.ColumnCount; i++)
            {
                MenorEncontrado = int.MaxValue;

                for (int j = 0; j < dtgDatosDelEjercicio.RowCount; j++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[j].Cells[i].Value.ToString(), out value))
                    {
                        if (MenorEncontrado > value)
                        {
                            MenorEncontrado = value;
                        }
                    }
                }

                for (int j = 0; j < dtgDatosDelEjercicio.RowCount; j++)
                {
                    int value;
                    if(int.TryParse(dtgDatosDelEjercicio.Rows[j].Cells[i].Value.ToString(), out value))
                    {
                        dtgDatosDelEjercicio.Rows[j].Cells[i].Value = value - MenorEncontrado;
                    }
                    
                }
            }
        }

        private void btnResolverProblema_Click(object sender, EventArgs e)
        {
            GuardarMatrizOriginal();
            intFilas = int.Parse(txtFilas.Text);
            intColumnas = int.Parse(txtColumnas.Text);
            TablaConTachas = new int[intFilas, intColumnas];
            FilasCantidadDeCero = new int[intFilas];
            ColumnasCantidadDeCeros = new int[intFilas];
            

            ImprimirTabla();
            CantidadDeTachasUtilizadas = 0;
            PrimerPasoRestarEnFilaConElMenor();
            SegundoPasoRestarColumnaConElMenor();
            while (CantidadDeTachasUtilizadas != intFilas)
            {
                LLenarDefaultTablaConTachados();
                
                CantidadDeTachasUtilizadas = 0;
                UbicarCeros();
                //ImprimirTabla();
                //ImprimirUbicacionCeros();
                TacharCeros2();
                PintarTachas();
                if (CantidadDeTachasUtilizadas != intFilas)
                {
                    OperacionesConElDatoMenor();
                }
                DespintarTachas();

            }
            MessageBox.Show("antes de asignacion");

            AsignacionesFinales();
            CalcularCostoFinal();

        }
        private void ContarCerosFilaDatagridView()
        {
            for (int columna = 0; columna < intColumnas; columna++)
            {
                FilasCantidadDeCero[columna] = 0;
            }

            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString(), out value))
                    {
                        if (value == 0 /*&& TablaConTachas[fila, columna] == 0*/)
                        {
                            FilasCantidadDeCero[fila] += 1;
                        }
                    }
                }
            }
        }


        private void MaximizarDatos()
        {
            for (int i = 0; i < intFilas; i++)
            {
                for (int j = 0; j < intColumnas; j++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[i].Cells[j].Value.ToString(), out value))
                    {
                        dtgDatosDelEjercicio.Rows[i].Cells[j].Value = value * (-1);
                    }
                }
            }
        }

        private void dtgDatosDelEjercicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtgDatosDelEjercicio.Rows.Clear();
            dtgDatosDelEjercicio.Columns.Clear();
        }

        private void dtgDatosDelEjercicio_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var cell = dtgDatosDelEjercicio.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    if (!int.TryParse(cell.Value.ToString(), out _))
                    {
                        cell.Value = null;
                    }
                }
            }
        }
        private void PintarTachas()
        {
            for (int i = 0; i < intFilas; i++)
            {
                for (int j = 0; j < intColumnas; j++)
                {
                    if (TablaConTachas[i,j] == 1)
                    {
                        if (dtgDatosDelEjercicio.Rows[i].Cells[j].Style.BackColor != Color.Red)
                        {
                            dtgDatosDelEjercicio.Rows[i].Cells[j].Style.BackColor = Color.Red;
                        }

                    }
                    else
                    {
                        if (TablaConTachas[i,j] == 2)
                        {
                            if (dtgDatosDelEjercicio.Rows[i].Cells[j].Style.BackColor != Color.GreenYellow)
                            {
                                dtgDatosDelEjercicio.Rows[i].Cells[j].Style.BackColor = Color.GreenYellow;
                            }
                        }
                    }
                }
            }
        }
        private void DespintarTachas()
        {
            for (int i = 0; i < intFilas; i++)
            {
                for (int j = 0; j < intColumnas; j++)
                {
                    dtgDatosDelEjercicio.Rows[i].Cells[j].Style.BackColor = default;
                }
            }

        }
        private void LLenarDefaultTablaConTachados()
        {
            UbicacionDeCeros = new int[intFilas, intColumnas];
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    TablaConTachas[fila, columna] = 0;
                    UbicacionDeCeros[fila,columna] = 0;
                }
            }
        }

        int[,] UbicacionDeCeros;
        int CantidadDeCerosTotales = 0;

        private void UbicarCeros()
        {
            CantidadDeCerosTotales = 0;
            UbicacionDeCeros = new int[intFilas, intColumnas];
            for (int fila = 0; fila < intFilas; fila++)
            {
                for(int columna = 0; columna < intColumnas; columna++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString(), out value))
                    {
                        if (value == 0)
                        {
                            UbicacionDeCeros[fila, columna] = 1;
                            CantidadDeCerosTotales++;
                        }
                        else
                        {
                            UbicacionDeCeros[fila, columna] = 0;
                        }
                    }
                }
            }


        }
        private void ImprimirUbicacionCeros()
        {

            string strtabla = "Ubicacion ceros\n";
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    strtabla += UbicacionDeCeros[fila, columna].ToString() + " ";
                }
                strtabla += "\n";
            }
            MessageBox.Show(strtabla);
        }
        
        private bool HayCeros()
        {
            CantidadDeCerosTotales = 0;
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    if (UbicacionDeCeros[fila,columna] == 1)
                    {
                        CantidadDeCerosTotales++;
                    }
                }
            }
            if (CantidadDeCerosTotales > 0)
            {
                return true;
            }
            else { return false; }
        }

        private void ContarCerosUbicacionCeros()
        {
            for (int i = 0; i < FilasCantidadDeCero.Length; i++)
            {
                FilasCantidadDeCero[i] = 0;
            }

            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    if (UbicacionDeCeros[fila,columna] == 1)
                    {
                        FilasCantidadDeCero[fila] += 1;
                    }
                }
            }
        }
        int[,] CoordenadasCeroAsignado;
        private void AsignacionesFinales()
        {
            UbicarCeros();
            ContarCerosUbicacionCeros();
            ImprimirUbicacionCeros();
            int FilasCubiertas = 0;
            int[] filasCompletadas = new int[intFilas];
            CoordenadasCeroAsignado = new int[intFilas, 2];

            while (FilasCubiertas != intFilas)
            {

                for (int fila = 0; fila < intFilas; fila++)
                {
                    //ImprimirFilas();
                    ImprimirUbicacionCeros();
                    
                    if (FilasCantidadDeCero[fila] == 1)
                    {
                        
                        FilasCantidadDeCero[fila] = 0;
                        FilasCubiertas++;
                        filasCompletadas[fila] = 1;
                        AsignarUnCero(fila);
                        ContarCerosUbicacionCeros();
                    }

                }

                for (int fila = 0; fila < intFilas; fila++)
                {

                    if (filasCompletadas[fila] == 0)
                    {
                        FilasCantidadDeCero[fila] = 0;
                        FilasCubiertas++;
                        filasCompletadas[fila] = 1;
                        AsignarUnCero(fila);
                        ContarCerosUbicacionCeros();
                        break;
                    }
                }




            }

        }

        private void AsignarUnCero(int fila)
        {
            int x = 0;
            int y = 0;


            for (int columna = 0; columna < intColumnas; columna++)
            {
                if (UbicacionDeCeros[fila, columna] == 1)
                {
                    x = fila;
                    y = columna;
                    CoordenadasCeroAsignado[fila, 0] = x;
                    CoordenadasCeroAsignado[fila, 1] = y;


                    UbicacionDeCeros[fila, columna] = 0;
                    dtgDatosDelEjercicio.Rows[x].Cells[y].Style.BackColor = Color.Yellow;

                    for (int i = 0; i< intColumnas; i++)
                    {

                        UbicacionDeCeros[fila, i] = 3;
                    }
                    break;

                }

            }
            for (int fila2 = 0; fila2 < intFilas; fila2++)
            {
                //MessageBox.Show("Fila: " + fila2 + "\n" + "columna: " + y);
                UbicacionDeCeros[fila2, y] = 3;
            }
        }


        private void CalcularCostoFinal()
        {
            string str = "";
            int CostoMinimoTotal = 0;

            for (int i = 0; i< intFilas; i++)
            {
                CostoMinimoTotal += MatrizOriginalProblema[CoordenadasCeroAsignado[i,0],CoordenadasCeroAsignado[i,1]];
                str += CostoMinimoTotal.ToString() + " + ";

            }
            MessageBox.Show("Costo minimo: " + CostoMinimoTotal.ToString() + "\nSumas: " + str);
        }

        private void TacharCeros2()
        {
            while (HayCeros())
            {
                ContadorDeCeros();
                for (int fila = 0; fila < intFilas; fila++)
                {
                    
                    for (int columna = 0; columna < intColumnas; columna++)
                    {

                        if (UbicacionDeCeros[fila, columna] == 1)
                        {
                            if (ColumnasCantidadDeCeros[columna] > FilasCantidadDeCero[fila])
                            {
                                CantidadDeTachasUtilizadas++;
                                UbicacionDeCeros[fila, columna] = 0;

                                for (int fila2 = 0; fila2 < intFilas; fila2++)
                                {
                                    UbicacionDeCeros[fila2, columna] = 0;

                                    if (TablaConTachas[fila2, columna] == 0)
                                    {
                                        TablaConTachas[fila2, columna] = 1;
                                    }
                                    else
                                    {
                                        if (TablaConTachas[fila2, columna] == 1)
                                        {
                                            TablaConTachas[fila2, columna] = 2;
                                        }
                                    }

                                }
                            }
                            else
                            {
                                if (ColumnasCantidadDeCeros[columna] < FilasCantidadDeCero[fila])
                                {
                                    CantidadDeTachasUtilizadas++;
                                    UbicacionDeCeros[fila, columna] = 0;

                                    for (int fila2 = 0; fila2 < intFilas; fila2++)
                                    {
                                        UbicacionDeCeros[fila, fila2] = 0;
                                        if (TablaConTachas[fila, fila2] == 0)
                                        {
                                            TablaConTachas[fila, fila2] = 1;
                                        }
                                        else
                                        {
                                            if (TablaConTachas[fila, fila2] == 1)
                                            {
                                                TablaConTachas[fila, fila2] = 2;
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    if (ColumnasCantidadDeCeros[columna] == 1 && FilasCantidadDeCero[fila] == 1)
                                    {
                                        CantidadDeTachasUtilizadas++;
                                        
                                        UbicacionDeCeros[fila, columna] = 0;
                                        for (int fila2 = 0; fila2 < intFilas; fila2++)
                                        {
                                            UbicacionDeCeros[fila, fila2] = 0;
                                            if (TablaConTachas[fila, fila2] == 0)
                                            {
                                                TablaConTachas[fila, fila2] = 1;
                                            }
                                            else
                                            {
                                                if (TablaConTachas[fila, fila2] == 1)
                                                {
                                                    TablaConTachas[fila, fila2] = 2;
                                                }
                                            }

                                        }
                                    }
                                }

                            }


                        }
                    }
                    
                }
                
            }

        }
        private void ContadorDeCeros()
        {
            for (int i = 0; i < ColumnasCantidadDeCeros.Length; i++)
            {
                ColumnasCantidadDeCeros[i] = 0;
                FilasCantidadDeCero[i] = 0;
            }


            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    int value;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString(), out value))
                    {
                        if (value == 0 && TablaConTachas[fila,columna] == 0)
                        {
                            FilasCantidadDeCero[fila] += 1;
                        }
                    }
                }

                for (int fila2 = 0; fila2 < intFilas; fila2++)
                {
                    int value2;
                    if (int.TryParse(dtgDatosDelEjercicio.Rows[fila2].Cells[fila].Value.ToString(), out value2))
                    {
                        if (value2 == 0 && TablaConTachas[fila2, fila] == 0)
                        {
                            ColumnasCantidadDeCeros[fila] += 1;
                        }

                    }
                }

            }

            string strFilasCeros = "";
            for ( int i = 0; i < FilasCantidadDeCero.Length; i++)
            {
                strFilasCeros += FilasCantidadDeCero[i].ToString();
            }


            string strColumnasCeros = "";
            for (int i = 0; i < ColumnasCantidadDeCeros.Length; i++)
            {
                strColumnasCeros += ColumnasCantidadDeCeros[i].ToString();
            }
            MessageBox.Show(strFilasCeros + "\n" + strColumnasCeros);




        }
        private int ObtenerDatoMenorNoTachado()
        {
            int intNumeroMenor = int.MaxValue;
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    if (TablaConTachas[fila, columna] == 0)
                    {
                        if (int.Parse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString()) < intNumeroMenor)
                        {
                            intNumeroMenor = int.Parse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString());
                        }
                    }
                }
            }
            return intNumeroMenor;
        }
        private void OperacionesConElDatoMenor()
        {
            int intNumeroMenor = ObtenerDatoMenorNoTachado();
            //MessageBox.Show(intNumeroMenor.ToString());
            for (int fila = 0; fila < intFilas; fila++)
            {
                for (int columna = 0; columna < intColumnas; columna++)
                {
                    if (TablaConTachas[fila, columna] == 0)
                    {
                        dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value = int.Parse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString()) - intNumeroMenor;
                    }
                    if (TablaConTachas[fila, columna] == 2)
                    {
                        dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value = int.Parse(dtgDatosDelEjercicio.Rows[fila].Cells[columna].Value.ToString()) + intNumeroMenor;
                    }

                }
            }
        }
        private int BuscarMayoresFila(int[] FilasCantidadDeCeros)
        {
            int intNumeroMayor = int.MinValue;
            for (int fila = 0; fila < FilasCantidadDeCeros.Length; fila++)
            {
                if (FilasCantidadDeCeros[fila] > intNumeroMayor)
                {
                    intNumeroMayor = FilasCantidadDeCeros[fila];
                }
            }
            return intNumeroMayor;
        }
        private int BuscarMayoresColumnas(int[] ColumnasCantidadDeCeros)
        {
            int intNumeroMayor = int.MinValue;
            for (int columna = 0; columna < ColumnasCantidadDeCeros.Length; columna++)
            {
                if (ColumnasCantidadDeCeros[columna] > intNumeroMayor)
                {
                    intNumeroMayor = ColumnasCantidadDeCeros[columna];
                }
            }
            return intNumeroMayor;
        }


        private void TacharConLineaLosCeros()
        {

            //ContadorDeCeros();
            int[] CerosFilasTotales = ColumnasCantidadDeCeros;
            int[] CerosColumnasTotales = FilasCantidadDeCero;
            int intNumeroMayorFila = BuscarMayoresFila(FilasCantidadDeCero);
            int intNumeroMayorColumna = BuscarMayoresColumnas(ColumnasCantidadDeCeros);
            //MessageBox.Show(intNumeroMayorFila.ToString());
            //MessageBox.Show(intNumeroMayorColumna.ToString());

            if (intNumeroMayorColumna == 0 && intNumeroMayorFila == 0)
            {
                //HayCeros = false;
                return;
            }
            //if (intNumeroMayorColumna == intNumeroMayorFila)
            //{

            //    MessageBox.Show("Valro de ceros filas max: " + CerosFilasTotales.Max().ToString() + "\n" + "Valor de ceros columna max: " + CerosColumnasTotales.Max().ToString());
            //    if (CerosFilasTotales.Max() < CerosColumnasTotales.Max())
            //    {

            //        TacharColumnaDeCeros(intNumeroMayorColumna);

            //    }
            //    else
            //    {
            //        TacharFilaDeCeros(intNumeroMayorFila);

            //    }
            //}
            if (intNumeroMayorFila <= intNumeroMayorColumna)
            {
                //MessageBox.Show("Entro en columnas");
                TacharColumnaDeCeros(intNumeroMayorColumna);

            }
            else
            {
                TacharFilaDeCeros(intNumeroMayorFila);
            }

            CantidadDeTachasUtilizadas += 1;//El incrementador de tachas

        }

        private void TacharFilaDeCeros(int CantidadDeCeros)
        {
            for (int fila = 0; fila < FilasCantidadDeCero.Length; fila++)
            {
                if (FilasCantidadDeCero[fila] == CantidadDeCeros)
                {
                    FilasCantidadDeCero[fila] = 0;
                    for (int i = 0; i < intFilas; i++)
                    {
                        if (TablaConTachas[fila, i] == 1) { TablaConTachas[fila, i] = 2; }
                        else
                        {
                            TablaConTachas[fila, i] = 1;

                        }
                    }
                    break;
                }
            }
        }
        private void TacharColumnaDeCeros(int CantidadDeCeros)
        {
            for (int columna = 0; columna < ColumnasCantidadDeCeros.Length; columna++)
            {
                if (ColumnasCantidadDeCeros[columna] == CantidadDeCeros)
                {
                    ColumnasCantidadDeCeros[columna] = 0;
                    for (int i = 0; i < intColumnas; i++)
                    {
                        if (TablaConTachas[i, columna] == 1)
                        {

                            TablaConTachas[i, columna] = 2;


                        }
                        else
                        {
                            TablaConTachas[i, columna] = 1;
                        }

                    }
                    break;
                }

            }
        }




        private void CargarEjercicioUno()
        {
            dtgDatosDelEjercicio.Columns.Add("column1", "1");
            dtgDatosDelEjercicio.Columns.Add("column2", "2");
            dtgDatosDelEjercicio.Columns.Add("column3", "3");
            dtgDatosDelEjercicio.Columns.Add("column4", "4");
            dtgDatosDelEjercicio.Columns.Add("column5", "5");
            dtgDatosDelEjercicio.Columns.Add("column6", "6");
            dtgDatosDelEjercicio.Rows.Add(6);

            MatrizOriginalProblema = new int[,]{
                { 260, 245, 278, 310, 261, 239 },
            { 245 ,296, 338, 275, 282, 258 },
            { 254, 245, 214, 234, 219, 233 },
            { 224, 272, 236, 265, 263, 255 },
            { 236, 260, 255, 230, 265, 243 },
            { 0, 0, 0, 0, 0, 0 }
            };

            txtColumnas.Text = "6";
            txtFilas.Text = "6";
            RellenarDataGridView(MatrizOriginalProblema);

        }

        private void RellenarDataGridView(int[,] ejercicio)
        {
            for (int j = 0; j < dtgDatosDelEjercicio.RowCount; j++)
            {
                for (int i = 0; i < dtgDatosDelEjercicio.ColumnCount; i++)
                {
                    dtgDatosDelEjercicio.Rows[j].Cells[i].Value = ejercicio[j, i];
                }
            }
        }
        private void CargarEjercicioDos()
        {

            dtgDatosDelEjercicio.Columns.Add("column", "1");
            dtgDatosDelEjercicio.Columns.Add("column1", "2");
            dtgDatosDelEjercicio.Columns.Add("column2", "3");
            dtgDatosDelEjercicio.Columns.Add("column3", "4");
            dtgDatosDelEjercicio.Rows.Add(4);
            txtColumnas.Text = "4";
            txtFilas.Text = "4";


            MatrizOriginalProblema = new int[,]
            {
            { 48,48,50,44 },
            { 56,60,60,68},
            { 92,94,90,85},
            {42,44,54,46},
            };



            RellenarDataGridView(MatrizOriginalProblema);

        }
        private void CargarEjercicioTres()
        {

            dtgDatosDelEjercicio.Columns.Add("column", "1");
            dtgDatosDelEjercicio.Columns.Add("column1", "2");
            dtgDatosDelEjercicio.Columns.Add("column2", "3");
            dtgDatosDelEjercicio.Columns.Add("column3", "4");
            dtgDatosDelEjercicio.Rows.Add(4);
            MatrizOriginalProblema = new int[,]{
                { 10,15,9,0 },
            { 9,18,5,0},
            { 6,14,3, 0},
            {8,16,6,0},
            };

            txtColumnas.Text = "4";
            txtFilas.Text = "4";
            RellenarDataGridView(MatrizOriginalProblema);

        }
        //private void AsignarCeros

    }




}
