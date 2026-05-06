import 'package:file_picker/file_picker.dart';
import 'package:flutter/foundation.dart';
import 'package:image_picker/image_picker.dart';
import 'dart:io';
import 'dart:typed_data';
import 'package:flutter/material.dart';

class FilePickerButton extends StatefulWidget {
  final Function(PlatformFile?)
  onFilesSelected; // ← PlatformFile au lieu de File

  const FilePickerButton({Key? key, required this.onFilesSelected})
    : super(key: key);

  @override
  State<FilePickerButton> createState() => _FilePickerButtonState();
}

class _FilePickerButtonState extends State<FilePickerButton> {
  final ImagePicker _imagePicker = ImagePicker();

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
                const Padding(
                  padding: EdgeInsets.only(bottom: 16),
                  child: Text(
                    'Choisir une source',
                    style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                ),
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
                  subtitle: const Text('Sélectionner une image'),
                  onTap: () {
                    Navigator.pop(context);
                    _pickImages();
                  },
                ),
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

  // Convertit un XFile en PlatformFile (compatible Web + Mobile)
  Future<PlatformFile> _xFileToPlatformFile(XFile xFile) async {
    if (kIsWeb) {
      // Sur le Web, lire les bytes
      final bytes = await xFile.readAsBytes();
      return PlatformFile(name: xFile.name, size: bytes.length, bytes: bytes);
    } else {
      // Sur Mobile, utiliser le path
      final file = File(xFile.path);
      final size = await file.length();
      return PlatformFile(name: xFile.name, size: size, path: xFile.path);
    }
  }

  Future<void> _pickImages() async {
    try {
      final XFile? image = await _imagePicker.pickImage(
        source: ImageSource.gallery,
        maxWidth: 1920,
        maxHeight: 1920,
        imageQuality: 85,
      );

      if (image != null) {
        final platformFile = await _xFileToPlatformFile(image);
        widget.onFilesSelected(platformFile);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la sélection des images');
    }
  }

  Future<void> _takePhoto() async {
    try {
      final XFile? photo = await _imagePicker.pickImage(
        source: ImageSource.camera,
        maxWidth: 1920,
        maxHeight: 1920,
        imageQuality: 85,
      );

      if (photo != null) {
        final platformFile = await _xFileToPlatformFile(photo);
        widget.onFilesSelected(platformFile);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la prise de photo');
    }
  }

  Future<void> _pickPDF() async {
    try {
      FilePickerResult? result = await FilePicker.platform.pickFiles(
        type: FileType.custom,
        allowedExtensions: ['pdf'],
        allowMultiple: false,
        withData: true, // ← CRUCIAL pour le Web
      );

      if (result != null) {
        widget.onFilesSelected(result.files.single);
      }
    } catch (e) {
      _showSnackBar('Erreur lors de la sélection du PDF $e');
    }
  }

  void _showSnackBar(String message) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(message), duration: const Duration(seconds: 2)),
    );
  }

  @override
  Widget build(BuildContext context) {
    return ElevatedButton.icon(
      onPressed: _showPickerOptions,
      icon: const Icon(Icons.attach_file),
      label: const Text('Transférer un nouveau document'),
      style: ElevatedButton.styleFrom(
        padding: const EdgeInsets.symmetric(horizontal: 24, vertical: 14),
        shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(10)),
      ),
    );
  }
}
