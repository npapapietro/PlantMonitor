   M S B A M L   `   `   `  ���� G  CPlantMonitor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PlantMonitorPlantMonitor      PlantMonitor.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:PlantMonitor       � Title$  
MainWindow��$	��350��$	��600��.��]� $��2q�.+�o� $	��Top=�.@�m� $��_File��.@�m� -    m�Name$
 Open��$��_Open��m� -   $
 Save��$��_Save��m� -   $ CloseMW��$��_Close��c� -   $��	MyToolbar��$	��Top=�$
��Auto��.@�	� -   $��GetRectangle�����	#FF969696$��Manage��$
��Auto��$��75�� 	� 	GroupName$ 
ShapeGroup���� $��20��
������ �� -   $��AddRow�����	#FF969696$��Add Row��$
��Auto��$��75���� -   $��AddCol�����	#FF969696$��Add Col��$
��Auto��$��75��	� -   $��RemoveButton�����	#FF969696$��Remove��$
��Auto��$��75��$ 
ShapeGroup��(� $
��Auto��$
��Auto��.��� -	   $��
GlobalGrid��$	��570��$
��Auto�� � ColumnDefinitions �� $	��200 ��� $	��370 � � RowDefinitions �� $	��300 �.+��� 
�������$��2q�
�������._�� $��0��$��0�� �� $��25 ��� $��10 ��� .+��� -
    ��Name$ 	LeftLabel��$��Overview��$��0��$��0���� $��0��$��1��&   System.Windows.Controls.DataGrid  -     Name$ OverviewGrid��$��0��$��2��$��10,10,10,10q�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    
IsReadOnly . 	   AutoGenerateColumns	 .  
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$	 Key�  $ Total Number�� �� $ Value�� $��1��$��0��.+��� -   $��CanvasScroll��$
��Auto=�$
��Auto=�.���� -    ��Name$ MyCanvas��$��62��$��62��
�������