import 'package:flutter/material.dart';

class HomePage extends StatelessWidget{
  @override
  Widget build(BuildContext context)
  {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Colors.blue,
        leading: Icon(
          Icons.menu,
        ),
        title: Text(
          'NurseryLink',
        ),
        actions: [
          IconButton(icon:
          Icon(
            Icons.notification_add,

          ), onPressed: (){} ,
          ),
          IconButton(icon:
          Icon(
            Icons.search,

          ), onPressed: (){} ,
          ),






        ],
      ),
      body: SafeArea(child: Text(
        ''
      ),
      ),
    );
  }
  
}