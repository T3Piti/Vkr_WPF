   M S B A M L   `   `   `  ����B  >Vkr_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Vkr_WPF.Views.WindowsVkr_WPF.Views.Windows  5   	   *    $Vkr_WPF.Views.Windows.AddStageWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Vkr_WPF.Views.Windows     5   	     � Title$%  Добавление этапа��5   	   $	��360��5	   	   $	��350��6   $0��*/Vkr_WPF;component/Fonts/#Natural Mono Alt)�5
   	   ���#DBDBEA � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5         
LabelStyle �� 
TargetType �� Property �� Value  TextBoxStyle��%�  &	        &	 �     �� 5   
   " ��6#   .�5      ��  � ��$ 30(�6)   �� 5       � ��$ Center=�64   �� 5       � �� �#0D0D2E6+   �� 5       � ��$ 5q�6'   5      �� 5   
   .�5      ��  � ��
 ���� 68   �� 5       � ��$ Center=�6F   �� 5       � ��$ 0q�6=   �� 5       � ��$ 5q�65   �� 5       � �� �#DBDBEA68   �� 5       � ��$ 20(�66   �� 5       � ��$	 280��63   5      5      .��5      ��  �� Orientation$ Vertical=�6   $��10q�6(   .+�5!   
   �� $!��Название этапа��6   #��[  6)   �� 5"   
    �� CornerRadius$ 10��6   ���#0D0D2E$	��300��5$      $��50��5%      $��5q�5&      ._�5'      � .+�5(      �� $��1��6   �� 5)      -   5         ��Name$ StageNameTextBox��5*      #��[ 5)      ��5+      �� *	StageName+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 5,       J� IsHitTestVisible .  $!��Название этапа��5-      $��Center=�5.      $
��Left=�5/      
�������$��13(�51       �� Padding$ 5q�52      $��10,0,0,0q�53      ��54      �� 55      " ��6     �� Triggers 56      �� 57   "    �� Binding 6.   �� *Text+ �� ElementName$ StageNameTextBox�� �� Value  6e   .a�58   &   ��  � y�$ Visible=�6C   59   #   .�5;      ��  � y�$ Hidden=�6;   5<      5>      5?      5@      �� 5C   
   $��Статус��6   #��[  6!   �� 5D   
   $	��300��6   $��50��6   $��20(�6+   $��5q�69    �� DisplayMemberPath$
 name��5G      ��5E      �� *StatusesList+$
 TwoWay=�$	 PropertyChanged=� �� SelectedItem 5F      �� *SelectedStatus+$
 TwoWay=�$	 PropertyChanged=�5G      �� 5J   
   $ 15��6   ���#0D0D2E$	��300��5L      $��50��5M      $��10q�5N      ._�5O      � .+�5P      �� $��1��6   �� 5Q      $	��300��6   
������ $��0q�5R      $��Добавить этап��5S      ���#DBDBEA$��20(�5U      ��5V      �� *AddStageCommand+5W      5X      5Y      5Z      