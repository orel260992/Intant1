   M S B A M L   `   `   `  ����F  BBlack-sklad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Black_skladBlack_sklad  5   	       Black_sklad.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Black_sklad     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Black-WareHouse��5	   	   $	��600��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5
      �  � Cursor$ Arrow��6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ Black��6   $ 1Q�6-   5      .+�5   
   �� $	��200��6   $��50q�6    $��2��6,   
�������$��Center=�5       �� Padding$ 30q�6,   $	��450��69    �� CornerRadius$ 30��6H   	 J� Effect	 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      
   
BlurRadius$	
 100Q�6#      Color$ 
BlueViolet��64      ShadowDepth$ 0Q�6G   ._�5      �� .+�5      �� $��Вход��6   $��30(�6(   $
��Bold"�66   $��0 0 0 20q�6H   � 5      $��0 0 0 20q�6   .+�5      �� -   5        $
��Left=�5      $��Регистрация��68   6N   �� 5      $��Right=�6   $��Вход��69    #  MaterialDesignFlatLightBgButton#��[  6H   5      �� 5      -   5         ��Name$ autlogin��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6,    % !MaterialDesignFloatingHintTextBox#��[ 6[   G� 5      -   5         G�Name$ autpass��5      $! Введите пароль��6/    ) %MaterialDesignFloatingHintPasswordBox#��[ 6_   �� 5       -   5        $��
Войти��5       $
��0 20q�6)   67   5!      5"       � ColumnDefinitions 5#   
   �� 5$      $��0* �6   �� 5%      �� 5&      $��0* �6   5*      5+      