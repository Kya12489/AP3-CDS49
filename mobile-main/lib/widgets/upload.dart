import 'package:file_picker/file_picker.dart';
import 'package:image_picker/image_picker.dart';
import 'dart:io';
import 'package:flutter/material.dart';

class FilePickerButton extends StatefulWidget {
  final Function(File?) onFilesSelected;

  const FilePickerButton({Key? key, required this.onFilesSelected})
    : super(key: key);

  @override
  State<FilePickerButton> createState() => _FilePickerButtonState();
}

class _FilePickerButtonState extends State<FilePickerButton> {
  File selectedFiles = File('');
  final ImagePicker _imagePicker = ImagePicker();

  // Afficher le bottom sheet pour choisir le type
  Future<void> _showPickerOptions() async {
    showModalBottomSheet(
      context: context,
      shape: const RoundedRectangleBorder(
        borderRadius: BorderRadius.vertical(top: Radius.circular(20)),
      ),
      builder: (BuildContext context) {
        return SafeArea(
          child: Padding(
            padding: const EdgeInsets.symmetric(vertical: 20),
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                // Titre
                const Padding(
                  padding: EdgeInsets.only(bottom: 16),
                  child: Text(
                    'Choisir une source',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                ),

                // Option Caméra
                ListTile(
                  leading: Container(
                    padding: const EdgeInsets.all(8),
                    decoration: BoxDecoration(
                      color: Colors.blue.withOpacity(0.1),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: const Icon(Icons.camera_alt, color: Colors.blue),
                  ),
                  title: const Text('Caméra'),
                  subtitle: const Text('Prendre une photo'),
                  onTap: () {
                    Navigator.pop(context);
                    _takePhoto();
                  },
                ),

                // Option Galerie
                ListTile(
                  leading: Container(
                    padding: const EdgeInsets.all(8),
                    decoration: BoxDecoration(
                      color: Colors.green.withOpacity(0.1),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: const Icon(Icons.photo_library, color: Colors.green),
                  ),
                  title: const Text('Galerie'),
                  subtitle: const Text('Sélectionner une images'),
                  onTap: () {
                    Navigator.pop(context);
                    _pickImages();
                  },
                ),

                // Option PDF
                ListTile(
                  leading: Container(
                    padding: const EdgeInsets.all(8),
                    decoration: BoxDecoration(
                      color: Colors.red.withOpacity(0.1),
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: const Icon(Icons.picture_as_pdf, color: Colors.red),
                  ),
                  title: const Text('Document PDF'),
                  subtitle: const Text('Sélectionner un fichier PDF'),
                  onTap: () {
                    Navigator.pop(context);
                    _pickPDF();
                  },
                ),

                // Bouton Annuler
                Padding(
                  padding: const EdgeInsets.only(top: 8),
                  child: TextButton(
                    onPressed: () => Navigator.pop(context),
                    child: const Text('Annuler'),
                  ),
                ),
              ],
            ),
          ),
        );
      },
    );
  }

  Future<void> _pickImages() async {
    try {
      final XFile? images = await _imagePicker.pickImage(
        source: ImageSource.gallery,
        maxWidth: 1920,
        maxHeight: 1920,
        imageQuality: 85,
      );

      if (images != null) {
        setState(() {
          selectedFiles = File(images.path);
        });
        widget.onFilesSelected(selectedFiles);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la sélection des images');
    }
  }

  // Prendre une photo
  Future<void> _takePhoto() async {
    try {
      final XFile? photo = await _imagePicker.pickImage(
        source: ImageSource.camera,
        maxWidth: 1920,
        maxHeight: 1920,
        imageQuality: 85,
      );

      if (photo != null) {
        setState(() {
          selectedFiles = File(photo.path);
        });
        widget.onFilesSelected(selectedFiles);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la prise de photo');
    }
  }

  // Sélectionner un PDF
  Future<void> _pickPDF() async {
    try {
      FilePickerResult? result = await FilePicker.platform.pickFiles(
        type: FileType.custom,
        allowedExtensions: ['pdf'],
        allowMultiple: false,
      );

      if (result != null && result.files.single.path != null) {
        setState(() {
          selectedFiles = File(result.files.single.path!);
        });
        widget.onFilesSelected(selectedFiles);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la sélection du PDF');
    }
  }

  void _showSnackBar(String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(message), duration: const Duration(seconds: 2)),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        // Afficher les fichiers sélectionnés

        // Bouton principal
        ElevatedButton.icon(
          onPressed: _showPickerOptions,
          icon: const Icon(Icons.attach_file),
          label: const Text('Transférer un nouveau document'),
          style: ElevatedButton.styleFrom(
            padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 14),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(10),
            ),
          ),
        ),
      ],
    );
  }
}
