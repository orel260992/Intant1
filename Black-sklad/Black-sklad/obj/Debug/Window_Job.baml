   M S B A M L   `   `   `  ����F  BBlack-sklad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Black_skladBlack_sklad  5   	       Black_sklad.Window_Job   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   %localclr-namespace:Black_sklad  5   	     � Title$  Black-WareHouse��5	   	   $	��900��6!   $
��1600��6.   .��5
      �  � Cursor$ Arrow��6   
���   �.+�5   
   �� $#��Монитор заказов��6   $
��Left=�6+   $	��Top=�6F   $	��182��6^   $��37��5       #  MaterialDesignFlatLightBgButton#��[  6   ��5      �� *monitor_Click+�� 5   
   $��Каталог��6   $
��Left=�6#   $	��Top=�6>   $	��182��6V   $��37��6b   $��	182,0,0,0q�6n   ��5      �� *catalog_Click+�� 5      $��
Склад��6   $
��Left=�6%   $	��Top=�6@   $	��182��6X   $��37��6d   $��	364,0,0,0q�6p   ��5      �� *warehous_Click+�� 5      $��Контрагенты��6   $
��Left=�6/   $	��Top=�6J   $	��182��6b   $��37��6n   $��	546,0,0,0q�6z   ��5      �� *counterpart_Click+�� 5   
   $��Статистика��6   $
��Left=�6&   $	��Top=�6A   $	��182��6Y   $��37��6e   $��	728,0,0,0q�6q   ��5      �� *
stat_Click+�� 5   
   -   5        $-��'Сменить пользователя��5      $��Right=�6J   $	��Top=�6f   $	��182��6~   $��37��6�   $��
1410,0,0,0q�6�    � 5   
   $��0,37,0,0q�6     � NavigationUIVisibility$ Hidden=�6"   ��6B   �� *CurrentPage+ J� Opacity 6b   �� *FrameOpacity+5      5      