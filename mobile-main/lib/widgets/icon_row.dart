import 'package:flutter/material.dart';

class IconRow extends Row {
  /// Custom AppBar 
  final List<Widget> children;
  final tring title,
  String content, {
  IconData? icon,
  bool isBtn = false,
  VoidCallback? onBtnPressed
  const IconRow({required this.children});
  @override

  @override
    Widget build(BuildContext context) {
      return Row(
       children: this.children,
      );
    }
}

