   M S B A M L   `   `   `  ����D  @CustomVPN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CustomVPN	CustomVPN  5   	   /clr-namespace:CustomVPN.CoreCustomVPN.Core  5   	   C&clr-namespace:CustomVPN.MVVM.ViewModelCustomVPN.MVVM.ViewModel  5   	       CustomVPN.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CustomVPN     5   	   3
extensionsclr-namespace:CustomVPN.Core     5   	   <	viewmodel&clr-namespace:CustomVPN.MVVM.ViewModel     5   	     � Title$  
MainWindow��5
   	   $	��450��5   	   $	��800��6    � WindowStyle$
 None=�5   	   
������  � AllowsTransparency$
 True��5   	    � 
ResizeMode$ 	CanResize=�5   	    � DataContext 5      ,  &CustomVPN.MVVM.ViewModel.MainViewModel  5   
   .��5      ]� ���#1e1e1e$��7q�5      .+�5   
   �� $��28��6   ���#252525$	��Top=�5       J� InputBindings 5      d� 5       d� MouseAction$ 	LeftClicke�6    �� Command 5      �� *MoveWindowCommand+._�5      �  � ColumnDefinitions 5      �� 5      6)   �� 5      $	��100 �6'   65   .+�5!      �� $��CustomVPN 1.0.0��6   
�������$��Consolas)�5#      $��Center=�5$      $��Center=�5%      $��	100,0,0,0q�5&      5'      �� 5(      $��1��6   	 �� Orientation$	 
Horizontal=�5)      $��Right=�5*      $��0,0,4,0q�5+      .+�5,      �� $
��🗕��6   $��0,0,0,3q�5-      ��5.      �� *MinimizeWindowCommand+�� 5/      $
��🗖��6   $��0,0,0,3q�50      ��51      �� *MaximizeWindowCommand+�� 52      $	��✕��6   $��0,0,0,2q�53      ��54      �� *ShutDownWindowCommand+55      56      57      �� 58   
   $��48��6   $
��Left=�59      ���#252525��5;      �� 5<      
 �� Triggers
 5=      :� 5>       :� RoutedEvent$ Border.MouseEnter��6'   [�5?      �� 5@   "   .��5A   &   �� .��5B   *   W�  �� TargetProperty$ (Border.Width)�6:   	 W� To 1205C   :    g� Duration$ 0:0:0.1D�5D   :   5E   '   5F   #   5H      :� 5I      $ Border.MouseLeave��6'   [�5J      �� 5K   "   .��5L   &   �� .��5M   *   W� $ (Border.Width)�6:    485N   :   $ 0:0:0.1D�5O   :   5P   '   5Q   #   5S      5U      ._�5W      �� .+�5X      	� $	��VPN��6     CustomVPN.Core.Extensions   Icon$
 🛡��5Y      $��7.6,3.5,8,0q�5Z      $��16(�5[      $��Normal"�5\      
������� d� 	IsChecked$
 TrueY�5^      ��5_      �� *ShowProtectionView+	� 5`      $	��VPN��6   $��16(�5a      $��Normal"�5b      
�������5c      	� 5d      $��Settings��6   $	 ⚙��5e      $��6,3.5,4.7,0q�5f      $��16(�5g      $��Normal"�5h      
���������5j      �� *ShowSettingsView+5k      5l      �� 5m   
   ��6   �� *CurrentView+5n      5o      