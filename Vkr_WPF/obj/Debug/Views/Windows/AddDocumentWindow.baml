   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Vkr_WPF.Views.WindowsVkr_WPF.Views.Windows  5   	   -    'Vkr_WPF.Views.Windows.AddDocumentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Vkr_WPF.Views.Windows     5   	     � Title$-  'Добавление документа��5   	   $	��450��6&   $	��800��63   $0��*/Vkr_WPF;component/Fonts/#Natural Mono Alt)�5	   	   ���#33334C � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%�  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ 25(�6)   �� 5       � ��$ Center=�64   �� 5       � �� �#DBDBEA6+   �� 5       � ��$ 5q�6'   5      �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5       .+�5"   
   Z� $
��Left=�6   $��10q�64   ��5#      ��  �� Path$ DocText� �� UpdateSourceTrigger$ PropertyChanged=��� 5$   
   $��1��6   .+�5%      �� 	 �� Orientation$	 
Horizontal=�6   .+�5&      �� $��Название:��6   #��[  6,   �� 5'      #��[  5(      ��5'      �� *
FileName+$ PropertyChanged=�
 �� Mode$
 TwoWay=�5(      5)      �� 5*      $	��300��6   $��50��6#   $��5q�6/    �� DisplayMemberPath$
 name��5-      $��20(�5.      ��5+      �� *StatusesList+ �� SelectedItem 5,      �� *SelectedStatus+$
 TwoWay=�$ PropertyChanged=�5.      �� 5/       �� CornerRadius$ 15��6   ���#0D0D2E$	��300��51      $��50��52      $��5q�53      ._�54      � .+�55      �� $��1��6    �� 56      $	��300��6   
������ $��0q�57   !   $%��Выбрать документ��58   !   ���#DBDBEA$��20(�5:   !   ��6/   �� *ChooseFileCommand+5;      5<      �� 5>      $ 15��6   ���#0D0D2E$	��300��5@      $��50��5A      $��5q�5B      ._�5C      � .+�5D      �� $��1��6    �� 5E      $	��300��6   
������ $��0q�5F   !   $'��!Добавить документ��5G   !   ���#DBDBEA$��20(�5I   !   ��6/   �� *AddDocumentCommand+5J      5K      5L      5M      5N      